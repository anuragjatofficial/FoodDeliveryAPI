
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FoodDeliveryAPI.DataAcces.Models
{
    [Table(name: "orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid OrderId { get; set; }

        [ForeignKey("User")]
        public Guid CustomerId { get; set; }
        [JsonIgnore]
        public Customer Customer { get; set; }

        [ForeignKey("DeliveryPerson")]
        public Guid DeliveryPersonId { get; set; }
        [JsonIgnore]
        public DeliveryPerson DeliveryPerson { get; set; }

        [ForeignKey("Restaurant")]
        public Guid RestaurantId { get; set; }
        [JsonIgnore]
        public Restaurant Restaurant { get; set; }

        //[ValidateOrderStatus]
        public string OrderStatus { get; set; }
        public List<Item> Items { get; set; }
<<<<<<< HEAD:FoodDeliveryAPI.DataAcces/Models/Order.cs
        public List<string> ValidStatuses { get; set; } = new List<string> {
=======
        public List<String> ValidStatuses { get; set; } = new List<String> { 
>>>>>>> 77c3c8d3869beb5d7929c4f1d13c2e05bd9b2655:FoodDeliveryAPI/Models/Order.cs
            Models.OrderStatus.PLACED,
            Models.OrderStatus.CANCELLED
        };
    }
}