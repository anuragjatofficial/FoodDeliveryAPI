
using FoodDeliveryAPI.DataAcces.Models;
using FoodDeliveryAPI.Domain.DTO;

namespace FoodDeliveryAPI.Domain.Service
{
    public interface IOrderService
    {
        Task<OrderDTO> PlaceOrder(OrderInput order);
        Task<string> UpdateOrderStatus(string status,Guid orderId);
        Task<List<OrderDTO>> GetAllOrders(int page,int pageSize);
        Task<OrderDTO> GetOrderByID(Guid orderId);
        Task<List<OrderDTO>> GetAllOrdersPlaced(Guid userId);
        Task<List<OrderDTO>> GetActiveOrders(Guid userId);
    }
}
