using FoodDeliveryAPI.Models;

namespace FoodDeliveryAPI.Service
{
    public interface ICustomerService
    {
       Task<Customer> AddCustomer(Customer customer);
       List<Customer> GetAllCustomers();
       Task<Customer> GetCustomerById(string id);
    }
}
