
using FoodDeliveryAPI.DataAcces.Models;
using FoodDeliveryAPI.Domain.DTO;

namespace FoodDeliveryAPI.Domain.Service
{
    public interface ICustomerService
    {
       Task<CustomerDTO> AddCustomer(Customer customer);
       IEnumerable<CustomerDTO> GetAllCustomers();
       Task<CustomerDTO> GetCustomerById(string id);
    }
}
