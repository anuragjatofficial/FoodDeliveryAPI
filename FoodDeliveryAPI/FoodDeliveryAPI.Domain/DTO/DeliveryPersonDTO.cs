using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryAPI.Domain.DTO
{
    public class DeliveryPersonDTO
    {
        public Guid UserId { get; set; }
        [Required(ErrorMessage ="username can't be null")]
        public string UserName { get; set; }
        [EmailAddress(ErrorMessage ="email can't be null")]
        [Required]
        public string UserEmail { get; set; }

        public DateTime? CreatedAt { get; set; }

    }
}
