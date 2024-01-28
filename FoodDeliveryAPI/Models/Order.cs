using FoodDeliveryAPI.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDeliveryAPI.Models
{
    [Table(name:"orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid OrderId { get; set; }

        [ForeignKey("User")]
        public Guid CustomerId { get; set; }

        Customer Customer { get; set; }

        [ForeignKey("DeliveryPerson")]
        public Guid DeliveryPersonId { get; set; }
            
        DeliveryPerson DeliveryPerson { get; set; }

        [ForeignKey("Restaurant")]
        public Guid RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        [ValidateOrderStatus]
        public string OrderStatus { get; set; } 
        public List<Item> Items { get; set; }
    }
}