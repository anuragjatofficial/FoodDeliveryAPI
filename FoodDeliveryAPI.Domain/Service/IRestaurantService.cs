using FoodDeliveryAPI.DataAcces.Models;
using FoodDeliveryAPI.Domain.DTO;

namespace FoodDeliveryAPI.Domain.Service
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
