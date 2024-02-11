using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryAPI.Domain.DTO
{
    public class UserCredentials
    {
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
