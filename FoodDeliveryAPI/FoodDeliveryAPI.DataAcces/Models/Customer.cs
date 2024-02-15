using System.Text.Json.Serialization;

namespace FoodDeliveryAPI.DataAcces.Models
{
    public class Customer : User
    {
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<Item> Cart { get; set; } = new List<Item>();
    }
}
