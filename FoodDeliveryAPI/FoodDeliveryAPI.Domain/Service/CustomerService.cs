using AutoMapper;
using FoodDeliveryAPI.DataAcces.Data;
using FoodDeliveryAPI.DataAcces.Models;
using FoodDeliveryAPI.Domain.DTO;
using FoodDeliveryAPI.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryAPI.Domain.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly FoodDeliveryAPIContext _context;
        private readonly IMapper _mapper;

        public CustomerService(FoodDeliveryAPIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CustomerDTO> GetCustomerById(string id)
        {
            return _mapper.Map<CustomerDTO>(await _context.Customers.Include(e => e.Orders).FirstOrDefaultAsync(e => e.UserId.ToString() == id) ?? throw new CustomerNotFoundException($"can't find any customer with id {id}"));
        }

        public async Task<CustomerDTO> AddCustomer(Customer customer)
        {
            if(customer != null)
            {
                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();
                return _mapper.Map<CustomerDTO>(customer);
            }
            throw new InvalidValueException("customer value can't be null");
        }

        // implement dynamic sorting , pagination , searching 

        public  IEnumerable<CustomerDTO> GetAllCustomers(string sortBy, string sortOrder, int page, int pageSize, string username)
        {

            var query = _context.Customers.AsQueryable();

            query = (!string.IsNullOrWhiteSpace(username)) ? query.Where(e=>e.UserName.Contains(username)) : query;

            switch (sortBy.ToLower())
            {
                case "userid":
                    query = sortOrder.ToLower() == "asc" ? query.OrderBy(c => c.UserId) :  query.OrderByDescending(c => c.UserId);
                    
                    break;
                
                case "username":
                    query =  sortOrder.ToLower() == "asc"? query.OrderBy(c=>c.UserName) : query.OrderByDescending(c => c.UserName);
                    break;

                case "useremail":
                    query = sortOrder.ToLower() == "asc" ? query.OrderBy(c => c.UserEmail) : query.OrderBy(c => c.UserEmail);
                    break;

            }

           return query
                    .Skip((page - 1 ) * pageSize)
                    .Take(pageSize)
                    .Select(customer => _mapper.Map<CustomerDTO>(customer));

        }

        public async Task<List<ItemDTO>> addItemsToCart(ItemDTO item, Guid userid)
        {
            var res = _context.Items.FirstOrDefault(it => it.ItemId == item.ItemId);
            

            if(res!=null)
            {
                var customer = await _context.Customers.Include(customer=>customer.Cart).FirstOrDefaultAsync(c => c.UserId == userid) ?? throw new CustomerNotFoundException($"can't find any customer with id {userid}");
                // check if customer's cart is empty or not 

                int totalCartItems = customer.Cart.Count();
                bool isItemSafeToAdd = false;

                if (totalCartItems != 0)
                {
                    // count to check how many items are not from the restaurant which we found from `res` variable's `restaurantId`
                    var count = customer.Cart.Where(e => e.RestaurantId != res.RestaurantId).Count();
                    if(count == 0)
                    {
                        // here we are safe to place order 
                        isItemSafeToAdd = true;
                    }
                    else if (count == totalCartItems)
                    {
                        // it means invalid items has been passed 
                        throw new InvalidValueException($"please remove other items to add this or add item from same restaurant");
                    }
                    else
                    {
                        // if we are here then it means any items is there in list whose restaurant id is different then others 
                        throw new Exception($"can't place order please try later");
                    }
                }
                else
                {
                    // here also we can add any item to cart as cart is empty 
                    isItemSafeToAdd = true;
                }
                if (isItemSafeToAdd)
                {
                    customer.Cart.Add(res);
                    await _context.SaveChangesAsync();
                    return customer.Cart.Select(it => _mapper.Map<ItemDTO>(it)).ToList();
                }
                else
                {
                    throw new Exception($"can't place order please try later"); 
                }
            }
            else
            {
                throw new ItemNotFoundException("can't find any item with id "+ item.ItemId);
            }
        }

        public async Task<List<ItemDTO>> removeItemsFromCart(Guid itemId,Guid userId)
        {
            var res = _context.Items.FirstOrDefault(i => i.ItemId == itemId);

            if(res!=null)
            {
                var customer = _context.Customers.Include(_customer => _customer.Cart).FirstOrDefault(c => c.UserId == userId) ?? throw new CustomerNotFoundException($"can't find any customer with id {userId}");
                customer.Cart.Remove(res);
                await _context.SaveChangesAsync();
                return customer.Cart.Select(item=>_mapper.Map<ItemDTO>(item)).ToList();
            }
            else
            {
                throw new ItemNotFoundException($"can't find any item with id {itemId}");
            }
        }

        public async Task<List<ItemDTO>> getCartItems(Guid id)
        {
            var customer = await _context.Customers.Include(c=>c.Cart).FirstOrDefaultAsync(cs => cs.UserId == id) ?? throw new CustomerNotFoundException($"can't find any customer with id {id}");
            return customer.Cart.Select(item=>_mapper.Map<ItemDTO>(item)).ToList();
        }

        public async Task<List<OrderDTO>> getAllOrders(Guid customerId)
        {
            var customer = await _context.Customers.Include(customer=>customer.Orders).FirstOrDefaultAsync(customer => customer.UserId == customerId) ?? throw new CustomerNotFoundException($"can't find any customer with id {customerId}");
            return customer.Orders.Select(order=>_mapper.Map<OrderDTO>(order)).ToList();
        }
    }
}
