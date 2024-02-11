using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FoodDeliveryAPI.DataAcces.Models
{
    public class DeliveryPerson : User
    {
        public List<Order> AllOrders { get; set; } = new List<Order>();
    }
}