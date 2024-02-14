
namespace FoodDeliveryAPI.Domain.DTO
{
    public class ItemDTO
    {
        public Guid ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double price { get; set; }
        public Guid RestaurantId { get; set; }
    }
}
