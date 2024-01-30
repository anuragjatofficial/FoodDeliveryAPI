using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FoodDeliveryAPI.Models
{
    public class DeliveryPerson : User
    {
        public List<Order> AllOrders { get; set; } = new List<Order>();
    }
}