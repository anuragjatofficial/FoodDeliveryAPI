using FoodDeliveryAPI.DataAcces.Data;
using FoodDeliveryAPI.DataAcces.Models;
using FoodDeliveryAPI.Domain.DTO;
using FoodDeliveryAPI.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryAPI.Domain.Service
{
    public class RestaurantService:IRestaurantService
    {
        private readonly FoodDeliveryAPIContext _context;
        public RestaurantService(FoodDeliveryAPIContext context)
        {
            _context = context;
        }

        public async Task<Restaurant> AddRestaurant(Restaurant restaurant)
        {
            if(restaurant != null)
            {
                await _context.Restaurants.AddAsync(restaurant);
                await _context.SaveChangesAsync();
                return restaurant;
            }
            throw new InvalidValueException("Restaurant can't be null");
        }

        public async Task<List<Restaurant>> GetAllRestaurants()
        {
            return await _context.Restaurants.ToListAsync();  
        }

        public async Task<Restaurant> GetRestaurantById(Guid id)
        {
            return await _context.Restaurants.Include(r => r.Items).FirstOrDefaultAsync(e => e.RestaurantId == id) ?? throw new RestaurantNotFoundException($"Can't find any restaurant with id {id}");
        }

        public async Task<String> ChangeRestaurantStatus(Guid id,bool status)
        {
            var restaurant = await  GetRestaurantById(id);
            restaurant.IsClosed = status;
            await _context.SaveChangesAsync();

            return restaurant
                    .IsClosed ? "Restaurant marked as closed succesfully " : "Restaurant marked as open succesfully";
        }

        public async Task<Item> AddItem(ItemDTO itemDto)
        {
            Item item = new Item()
            {
                Name = itemDto.Name,
                RestaurantId = itemDto.RestaurantId,
                Description = itemDto.Description,
                price = itemDto.price,
            };
            var restaurant = await GetRestaurantById(itemDto.RestaurantId);
            restaurant.Items.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
