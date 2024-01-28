namespace FoodDeliveryAPI.Models
{
    public class Customer : User
    {
        List<Order> Orders { get; set; }
    }
}
