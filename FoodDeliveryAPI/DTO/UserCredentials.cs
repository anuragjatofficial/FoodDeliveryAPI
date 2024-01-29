using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryAPI.DTO
{
    public class UserCredentials
    {
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
