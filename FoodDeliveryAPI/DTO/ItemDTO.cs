using FoodDeliveryAPI.Models;

namespace FoodDeliveryAPI.DTO
{
    public class ItemDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double price { get; set; }
        public Guid RestaurantId { get; set; }
    }
}
