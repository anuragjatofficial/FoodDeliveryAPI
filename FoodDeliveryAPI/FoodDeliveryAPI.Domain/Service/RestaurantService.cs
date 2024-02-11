using AutoMapper;
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

        private IMapper _mapper;
        public RestaurantService(FoodDeliveryAPIContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RestaurantDTOWithItem> AddRestaurant(Restaurant restaurant)
        {
            if(restaurant != null)
            {
                await _context.Restaurants.AddAsync(restaurant);
                await _context.SaveChangesAsync();
                return _mapper.Map<RestaurantDTOWithItem>(restaurant);
            }
            throw new InvalidValueException("Restaurant can't be null");
        }

        public async Task<List<RestaurantDTOWithItem>> GetAllRestaurants(
            int page,
            int pagesize,
            string restaurantName,
            string orderBy,
            string sortOrder
        )
        {
            var restaurant = new Restaurant();
            var query = _context.Restaurants.AsQueryable();
            query = (!string.IsNullOrWhiteSpace(restaurantName)) ? query.Where(r=>r.RestaurantName.Contains(restaurantName)) : query;
            switch (orderBy.ToLower())
            {
                case "restaurantname":
                    query = sortOrder.ToLower() == "desc" ? query.OrderByDescending(r => r.RestaurantName) : query.OrderBy(r => r.RestaurantName);
                    break;
                case "RestaurantId":
                    query = sortOrder.ToLower() == "desc" ? query.OrderByDescending(r => r.RestaurantId) : query.OrderBy(r=>r.RestaurantId);
                    break;
            }

            return await query
                            .Include(e=>e.Items)
                            .Skip((page-1)*pagesize)
                            .Take(pagesize)
                            .Select(r=>_mapper.Map<RestaurantDTOWithItem>(r))
                            .ToListAsync();
        }

        public async Task<RestaurantDTOWithItem> GetRestaurantById(Guid id)
        {
            return _mapper
                    .Map<RestaurantDTOWithItem>(
                        await _context
                                .Restaurants
                                .Include(r => r.Items)
                                .FirstOrDefaultAsync(e => e.RestaurantId == id) ?? throw new RestaurantNotFoundException($"Can't find any restaurant with id {id}")
                     );
        }

        public async Task<String> ChangeRestaurantStatus(Guid id,bool status)
        {
            var restaurant = await  GetRestaurantById(id);
            restaurant.IsClosed = status;
            await _context.SaveChangesAsync();

            return restaurant
                    .IsClosed ? "Restaurant marked as closed succesfully " : "Restaurant marked as open succesfully";
        }

        public async Task<ItemDTO> AddItem(ItemDTO itemDto)
        {
            Item item = new Item()
            {
                Name = itemDto.Name,
                RestaurantId = itemDto.RestaurantId,
                Description = itemDto.Description,
                price = itemDto.price,
            };
            var restaurant = await _context
                                    .Restaurants
                                    .Include(r => r.Items)
                                    .FirstOrDefaultAsync(e => e.RestaurantId == itemDto.RestaurantId) ?? throw new RestaurantNotFoundException($"Can't find any restaurant with id {itemDto.RestaurantId}");
            restaurant.Items.Add(item);
            await _context.SaveChangesAsync();
            return _mapper.Map<ItemDTO>(item);
        }
    }
}