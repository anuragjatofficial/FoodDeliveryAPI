using FoodDeliveryAPI.Input;
using FoodDeliveryAPI.Models;

namespace FoodDeliveryAPI.Service
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
