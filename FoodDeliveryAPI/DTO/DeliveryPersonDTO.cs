using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryAPI.DTO
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
