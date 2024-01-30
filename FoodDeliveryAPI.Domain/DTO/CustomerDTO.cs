<<<<<<< HEAD:FoodDeliveryAPI.Domain/DTO/CustomerDTO.cs
﻿using FoodDeliveryAPI.Domain.Validations;
using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryAPI.Domain.DTO
=======
﻿using FoodDeliveryAPI.Validations;
using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryAPI.DTO
>>>>>>> 77c3c8d3869beb5d7929c4f1d13c2e05bd9b2655:FoodDeliveryAPI/DTO/CustomerDTO.cs
{
    public class CustomerDTO
    {
        [Required]
<<<<<<< HEAD:FoodDeliveryAPI.Domain/DTO/CustomerDTO.cs
        public string? UserName { get; set; }
        [EmailAddress]
        public string? UserEmail { get; set; }
        [Required]
        public string? Password { get; set; }
=======
        public string UserName { get; set; }
        [EmailAddress]
        public string UserEmail { get; set; }
        [Required]
        public string Password { get; set; }
>>>>>>> 77c3c8d3869beb5d7929c4f1d13c2e05bd9b2655:FoodDeliveryAPI/DTO/CustomerDTO.cs

    }
}
