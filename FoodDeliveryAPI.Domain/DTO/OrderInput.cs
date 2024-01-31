using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryAPI.Domain.DTO
{
    public class OrderInput
    {
        [Required]
        public Guid CustomerId { get; set; }
        public Guid RestaurantId { get; set; }
        public List<Guid> ItemsId { get; set; }
    }
}
