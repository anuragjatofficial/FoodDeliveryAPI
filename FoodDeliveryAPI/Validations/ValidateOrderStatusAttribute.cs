using FoodDeliveryAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryAPI.Validations
{
    public class ValidateOrderStatusAttribute : Attribute
    {
        protected ValidationResult IsValid(
           string value,
           ValidationContext validationContext
        )
        {
            if (value!= OrderStatus.PLACED|| value != OrderStatus.CANCELLED || value != OrderStatus.PREPARED || value != OrderStatus.REACHED || value != OrderStatus.PICKEDUP || value != OrderStatus.ASSIGNED || value != OrderStatus.DELIVERED || value != OrderStatus.RECEIVED)
            {
                return new ValidationResult("Invalid order status");
            }

            return ValidationResult.Success;
        }
    }
}
