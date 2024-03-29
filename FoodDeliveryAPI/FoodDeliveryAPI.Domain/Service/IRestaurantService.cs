﻿using FoodDeliveryAPI.DataAcces.Models;
using FoodDeliveryAPI.Domain.DTO;
using Microsoft.Extensions.Primitives;

namespace FoodDeliveryAPI.Domain.Service
{
    public interface IRestaurantService
    {
        Task<IEnumerable<RestaurantDTOWithItem>> GetAllRestaurants(
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
        Task<int> GetAllRestaurantCount();
    }
}
