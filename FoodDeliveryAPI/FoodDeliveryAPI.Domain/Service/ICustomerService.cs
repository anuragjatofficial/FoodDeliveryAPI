
using FoodDeliveryAPI.DataAcces.Models;
using FoodDeliveryAPI.Domain.DTO;

namespace FoodDeliveryAPI.Domain.Service
{
    public interface ICustomerService
    {
       Task<CustomerDTO> AddCustomer(Customer customer);
       IEnumerable<CustomerDTO> GetAllCustomers(string sortBy, string sortOrder, int page, int pageSize,string username);
       Task<CustomerDTO> GetCustomerById(string id);

        Task<List<ItemDTO>> addItemsToCart(ItemDTO item, Guid userid);
        Task<List<ItemDTO>> removeItemsFromCart(Guid itemId, Guid userId);
        Task<List<ItemDTO>> getCartItems(Guid id);
        Task<List<OrderDTO>> getAllOrders(Guid customerId);
    }
}
