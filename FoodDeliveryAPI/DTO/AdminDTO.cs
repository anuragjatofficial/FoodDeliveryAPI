﻿using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryAPI.DTO
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
