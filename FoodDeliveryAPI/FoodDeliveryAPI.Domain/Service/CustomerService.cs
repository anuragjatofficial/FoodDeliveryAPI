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
    }
}
