using FoodDeliveryAPI.DataAcces.Models;
using FoodDeliveryAPI.Domain.DTO;

namespace FoodDeliveryAPI.Domain.Service
{
    public interface IRestaurantService
    {
        Task<List<RestaurantDTOWithItem>> GetAllRestaurants(
            int page,
            int pagesize,
            string restaurantName,
            string orderBy,
            string sortOrder
        );
        Task<RestaurantDTOWithItem> GetRestaurantById(Guid id);
        Task<RestaurantDTOWithItem> AddRestaurant(Restaurant restaurant);
        Task<String> ChangeRestaurantStatus(Guid id, bool status);
        Task<ItemDTO> AddItem(ItemDTO item);
    }
}
