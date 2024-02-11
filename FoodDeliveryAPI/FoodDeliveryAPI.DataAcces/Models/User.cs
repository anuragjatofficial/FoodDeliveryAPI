using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDeliveryAPI.DataAcces.Models
{
    [Index(nameof(UserName), IsUnique = true)]
    [Index(nameof(UserEmail), IsUnique = true)]
    public abstract class User
    {
        [Key]
        public Guid UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [EmailAddress]
        public string UserEmail { get; set; }

        public DateTime? CreatedAt { get; set; }
        [Required]
        //[ValidateRole]
        public string Role { get; set; }

        public string Password { get; set; }
    }
}
