using FoodDeliveryAPI;
using Microsoft.EntityFrameworkCore;
using FoodDeliveryAPI.DataAcces.Data;
using FoodDeliveryAPI.DataAcces.Models;
using FoodDeliveryAPI.Domain.DTO;
using FoodDeliveryAPI.Domain.Exceptions;
using AutoMapper;

namespace FoodDeliveryAPI.Domain.Service
{
    public class OrderService : IOrderService
    {
        private readonly FoodDeliveryAPIContext _context;
        private readonly IMapper _mapper;

        public OrderService(FoodDeliveryAPIContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderDTO> PlaceOrder(OrderInput order)
        {
            var restaurant = _context.Restaurants.FirstOrDefault(u=>u.RestaurantId==order.RestaurantId) ?? throw new RestaurantNotFoundException($"can't find any restaurant with id {order.RestaurantId}");
            var customer = _context.Customers.FirstOrDefault(u => u.UserId == order.CustomerId) ?? throw new CustomerNotFoundException($"can't find customer with id {order.CustomerId}");
            
            // check if restaurant is closed or not 

            if (restaurant.IsClosed)
            {
                throw new RestaurantClosedException($"can't place order because restaurant is closed");
            }

            var deliveryPerson = AssignDeliveryPerson();
              List<Item> items = new List<Item>();

            

            foreach(Guid Id in order.ItemsId)
            {
                // LINQ query to find out each item from restaurant 

                IQueryable<Item> it = from item in _context.Items 
                                      where item.ItemId == Id 
                                      where item.RestaurantId==order.RestaurantId 
                                      where item.isOutOfStock == false 
                                      select item;
                
                // getting each result item if item not found it throws exception that is handled in controllor 
                var i = it.FirstOrDefault() ?? throw new ItemNotFoundException($"can't find any item with id {Id} please remove to continue placing order");
                
                // adding each item to list 
                items.Add( i );
            }

            // creating new order instance to save data

            Order o = new Order()
            {
                CustomerId = order.CustomerId,
                RestaurantId = order.RestaurantId,
                Items = items,
                DeliveryPersonId = deliveryPerson.UserId,
                OrderStatus = OrderStatus.RECEIVED
            };

            // adding order to deliveryPerson's all orders 
            deliveryPerson.AllOrders.Add(o);

            // adding order to all customer orders 
            customer.Orders.Add(o);

            await _context.Orders.AddAsync(o);
            await _context.SaveChangesAsync(); 
            return _mapper.Map<OrderDTO>(o);
        }

        private DeliveryPerson AssignDeliveryPerson()
        {
            Random random = new Random();
            int toSkip = random.Next(0, _context.DeliveryPersons.Count());
            return _context.DeliveryPersons.OrderBy(r => Guid.NewGuid()).Skip(toSkip).Take(1).FirstOrDefault() ?? throw new NoDeliveyPersonFoundException($"can't find any available deliveryperson please try again later !");
        }

        public async Task<string> UpdateOrderStatus(string status,Guid orderId)
        {
            var order = await GetOrderByID(orderId);
            if(order.OrderStatus ==  status)
            {
                throw new StatusAlreadyUpdatedException($"status is already updated as {status}");
            }

            if (order.ValidStatuses.Contains(status))
            {
                switch(status)
                {
                    case "PLACED":
                        order.ValidStatuses.Remove(OrderStatus.PLACED);
                        order.ValidStatuses.Add(OrderStatus.ASSIGNED);
                        break;
                    case "ASSIGNED":
                        order.ValidStatuses.Remove(OrderStatus.ASSIGNED);
                        order.ValidStatuses.Add(OrderStatus.PREPARED);
                        break;
                    case "PREPARED":
                        order.ValidStatuses.Remove(OrderStatus.PREPARED);
                        order.ValidStatuses.Add(OrderStatus.PICKEDUP);
                        break;
                    case "REACHED":
                        order.ValidStatuses.Remove(OrderStatus.REACHED);
                        order.ValidStatuses.Add(OrderStatus.DELIVERED);
                        break;
                    case "DELIVERED":
                        order.ValidStatuses.Clear();
                        break;
                    case "CANCELLED":
                        order.ValidStatuses.Clear();
                        break;
                    default: break;
                }
                order.OrderStatus = status;
                await _context.SaveChangesAsync();
                return $"Order status maked as {status} succesfully";
            }

            throw new StatusAlreadyUpdatedException($"can't update status from {order.OrderStatus} to {status}");
        }

        public async Task<OrderDTO> GetOrderByID(Guid orderId)
        {
            return  _mapper.Map<OrderDTO>(await _context
                            .Orders
                            .Include(a => a.Items)
                            .FirstOrDefaultAsync(o => o.OrderId == orderId) ?? throw new OrderNotFoundException($"can't find any order with id {orderId}"));
        }

        public async Task<List<OrderDTO>> GetAllOrders()
        {
            return  await _context
                            .Orders
                            .Include(a => a.Items)
                            .Include(a=>a.Restaurant)
                            .Select(o=>_mapper.Map<OrderDTO>(o))
                            .ToListAsync();
        }

        public async Task<List<OrderDTO>> GetAllOrdersPlaced(Guid userId)
        {
            return await _context
                            .Orders
                            .Where(o=>o.CustomerId == userId)
                            .Select(o=>_mapper.Map<OrderDTO>(o))
                            .ToListAsync();
        }

        public async Task<List<OrderDTO>> GetActiveOrders(Guid userId)
        {
            return await _context
                            .Orders
                            .Where (o=>o.CustomerId == userId)
                            .Where(o=>o.OrderStatus != OrderStatus.CANCELLED && o.OrderStatus != OrderStatus.DELIVERED)
                            .Select(o=>_mapper.Map<OrderDTO>(o))
                            .ToListAsync();
        }

    }
}
