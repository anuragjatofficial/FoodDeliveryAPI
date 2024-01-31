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

        public  IEnumerable<CustomerDTO> GetAllCustomers()
        {
           return _context.Customers.ToList().Select(customer => _mapper.Map<CustomerDTO>(customer));
        }
    }
}
