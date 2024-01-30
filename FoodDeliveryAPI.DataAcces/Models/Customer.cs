using System.Text.Json.Serialization;

namespace FoodDeliveryAPI.DataAcces.Models
{
    public class Customer : User
    {
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
