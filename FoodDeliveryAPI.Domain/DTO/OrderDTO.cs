using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryAPI.Domain.DTO
{
    public class OrderDTO
    {
        [Required]
        public Guid CustomerId { get; set; }
        public Guid RestaurantId { get; set; }
        public List<Guid> ItemsId { get; set; }
    }
}
