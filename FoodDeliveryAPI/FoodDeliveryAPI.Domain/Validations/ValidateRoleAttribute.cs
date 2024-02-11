using FoodDeliveryAPI.DataAcces.Models;
using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryAPI.Domain.Validations
{
    public class ValidateRoleAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(
            object value,
            ValidationContext validationContext
        )
        {
            if(value.Equals( Role.USER))
            {
                Console.WriteLine("value is USER");
            }

            if (!value.Equals(Role.USER) && !value.Equals(Role.RESTAURANT_AGENT) && !value.Equals(Role.DELIVERY_PERSON) && !value.Equals(Role.SUPER_ADMIN) && !value.Equals(Role.ADMIN))
            {
                return new ValidationResult("Invalid role");
            }

            return ValidationResult.Success;
        }
    }
}
