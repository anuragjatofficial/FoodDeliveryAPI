using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryAPI.Domain.DTO
{
    public class UserDTO
    {
        [Required]
        public string UserName { get; set; } = null!;
        [EmailAddress]
        public string UserEmail { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
