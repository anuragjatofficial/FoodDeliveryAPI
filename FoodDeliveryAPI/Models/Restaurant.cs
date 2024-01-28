using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryAPI.Models
{
    public class Restaurant
    {
        public Guid RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        [Required]
        public string Address { get; set; }
        public bool IsClosed { get; set; }

        public List<Item> Items  {get;set;} = new List<Item>();
    }
}