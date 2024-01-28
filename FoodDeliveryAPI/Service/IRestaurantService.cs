using FoodDeliveryAPI.DTO;
using FoodDeliveryAPI.Models;

namespace FoodDeliveryAPI.Service
{
    public interface IRestaurantService
    {
        Task<List<Restaurant>> GetAllRestaurants();
        Task<Restaurant> GetRestaurantById(Guid id);
        Task<Restaurant> AddRestaurant(Restaurant restaurant);
        Task<String> ChangeRestaurantStatus(Guid id, bool status);
        Task<Item> AddItem(ItemDTO item);
    }
}
