using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDeliveryAPI.DataAcces.Models
{
<<<<<<< HEAD:FoodDeliveryAPI.DataAcces/Models/User.cs
    [Index(nameof(UserName), IsUnique = true)]
    [Index(nameof(UserEmail), IsUnique = true)]
=======
    [Index(nameof(UserName),IsUnique =true)]
    [Index(nameof(UserEmail),IsUnique =true)]
>>>>>>> 77c3c8d3869beb5d7929c4f1d13c2e05bd9b2655:FoodDeliveryAPI/Models/User.cs
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
