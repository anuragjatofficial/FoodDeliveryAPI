using System.ComponentModel.DataAnnotations;

<<<<<<< HEAD:FoodDeliveryAPI.Domain/DTO/DeliveryPersonDTO.cs
namespace FoodDeliveryAPI.Domain.DTO
=======
namespace FoodDeliveryAPI.DTO
>>>>>>> 77c3c8d3869beb5d7929c4f1d13c2e05bd9b2655:FoodDeliveryAPI/DTO/DeliveryPersonDTO.cs
{
    public class DeliveryPersonDTO
    {
        [Required(ErrorMessage ="username can't be null")]
        public string UserName { get; set; }
        [EmailAddress(ErrorMessage ="email can't be null")]
        [Required]
        public string UserEmail { get; set; }
        [Required(ErrorMessage ="password can't be empty or null")]
        public string Password { get; set; }
    }
}
