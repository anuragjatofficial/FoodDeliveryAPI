using FoodDeliveryAPI.Data;
using FoodDeliveryAPI.Exceptions;
using FoodDeliveryAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryAPI.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly FoodDeliveryAPIContext _context;

        public CustomerService(FoodDeliveryAPIContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetCustomerById(string id)
        {
            return await _context.Customers.FirstOrDefaultAsync(e=>e.UserId.ToString()==id) ?? throw new CustomerNotFoundException($"can't find any customer with id {id}") ;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            if(customer != null)
            {
                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();
                return customer;
            }
            throw new InvalidValueException("customer value can't be null");
        }

        public  List<Customer> GetAllCustomers()
        {
            return  _context.Customers.ToList();
        }
    }
}
