using FoodDeliveryAPI.Validations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDeliveryAPI.Models
{
   // [NotMapped]
    public abstract class User
    {
        [Key]
        public Guid UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [EmailAddress]
        public string UserEmail { get; set; }

        public DateTime? CreatedAt { get; set;}
        [Required]
        [ValidateRole]
        public string Role { get; set; }

        public string Password { get; set; }
    }
}
