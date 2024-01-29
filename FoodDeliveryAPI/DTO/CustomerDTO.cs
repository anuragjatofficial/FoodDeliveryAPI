using FoodDeliveryAPI.Validations;
using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryAPI.DTO
{
    public class CustomerDTO
    {
        [Required]
        public string UserName { get; set; }
        [EmailAddress]
        public string UserEmail { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
