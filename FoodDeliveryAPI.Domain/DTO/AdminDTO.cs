using System.ComponentModel.DataAnnotations;

<<<<<<< HEAD:FoodDeliveryAPI.Domain/DTO/AdminDTO.cs
namespace FoodDeliveryAPI.Domain.DTO
=======
namespace FoodDeliveryAPI.DTO
>>>>>>> 77c3c8d3869beb5d7929c4f1d13c2e05bd9b2655:FoodDeliveryAPI/DTO/AdminDTO.cs
{
    public class AdminDTO
    {
        [Required]
        public string UserName { get; set; } = null!;
        [EmailAddress]
        public string UserEmail { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
