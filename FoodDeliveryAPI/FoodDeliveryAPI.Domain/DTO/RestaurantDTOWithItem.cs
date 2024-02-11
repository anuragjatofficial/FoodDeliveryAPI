using FoodDeliveryAPI.DataAcces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Domain.DTO
{
    public class RestaurantDTOWithItem
    {
        public Guid RestaurantId { get; set; }
        public string RestaurantName { get; set; } = null!;
        public string Address { get; set; }

        public bool IsClosed { get; set; }

        public List<ItemDTO> Items { get; set; }
    }
}
