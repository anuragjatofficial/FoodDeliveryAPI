using System.Text.Json.Serialization;

namespace FoodDeliveryAPI.Models
{
    public class Customer : User
    {
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
