using System.ComponentModel.DataAnnotations;

<<<<<<< HEAD:FoodDeliveryAPI.Domain/DTO/UserCredentials.cs
namespace FoodDeliveryAPI.Domain.DTO
=======
namespace FoodDeliveryAPI.DTO
>>>>>>> 77c3c8d3869beb5d7929c4f1d13c2e05bd9b2655:FoodDeliveryAPI/DTO/UserCredentials.cs
{
    public class UserCredentials
    {
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
