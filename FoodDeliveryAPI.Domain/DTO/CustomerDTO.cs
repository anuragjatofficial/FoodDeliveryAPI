using FoodDeliveryAPI.Domain.Validations;
using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryAPI.Domain.DTO
{
    public class CustomerDTO
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        public Guid? UserId { get; set; }

        [EmailAddress]
        public string? UserEmail { get; set; }
        public DateTime? CreatedAt { get; set; }

    }
}
