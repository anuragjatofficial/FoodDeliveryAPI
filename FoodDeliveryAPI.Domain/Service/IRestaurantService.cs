using FoodDeliveryAPI.DataAcces.Models;
using FoodDeliveryAPI.Domain.DTO;

namespace FoodDeliveryAPI.Domain.Service
{
    public interface IRestaurantService
    {
        Task<List<RestaurantDTOWithItem>> GetAllRestaurants();
        Task<RestaurantDTOWithItem> GetRestaurantById(Guid id);
        Task<RestaurantDTOWithItem> AddRestaurant(Restaurant restaurant);
        Task<String> ChangeRestaurantStatus(Guid id, bool status);
        Task<ItemDTO> AddItem(ItemDTO item);
    }
}
