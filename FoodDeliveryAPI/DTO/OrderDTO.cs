using FoodDeliveryAPI.Models;
using FoodDeliveryAPI.Validations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryAPI.Input
{
    public class OrderDTO
    {
        [Required]
        public Guid CustomerId { get; set; }
        public Guid RestaurantId { get; set; }
        public List<Guid> ItemsId { get; set; }
    }
}
