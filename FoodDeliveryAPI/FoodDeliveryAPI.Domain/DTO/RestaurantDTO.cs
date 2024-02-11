namespace FoodDeliveryAPI.Domain.DTO
{
    public class RestaurantDTO
    {
        public Guid RestaurantId { get; set; }
        public string RestaurantName { get; set; } = null!;
        public string Address { get; set; }

    }   
}
