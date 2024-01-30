using System.Text.Json.Serialization;

namespace FoodDeliveryAPI.DataAcces.Models
{
    public class Item
    {
        public Guid ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double price { get; set; }
        public bool isOutOfStock { get; set; } = false;
        public Guid RestaurantId { get; set; }

        [JsonIgnore]
        public Restaurant Restaurant { get; set; }
    }
}