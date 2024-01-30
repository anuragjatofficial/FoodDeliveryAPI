
using FoodDeliveryAPI.DataAcces.Models;
using FoodDeliveryAPI.Domain.DTO;

namespace FoodDeliveryAPI.Domain.Service
{
    public interface IOrderService
    {
        Task<Order> PlaceOrder(OrderDTO order);
        Item FindOrderItemById(Guid itemId);
        Task<string> UpdateOrderStatus(string status,Guid orderId);
        Task<List<Order>> GetAllOrders();
        Task<Order> GetOrderByID(Guid orderId);
    }
}
