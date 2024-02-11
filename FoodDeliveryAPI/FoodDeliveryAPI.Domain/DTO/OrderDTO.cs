using FoodDeliveryAPI.DataAcces.Models;
using FoodDeliveryAPI.Domain.DTO;
using FoodDeliveryAPI.Domain.Exceptions;
using FoodDeliveryAPI.Domain.Validations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryAPI.Domain.DTO
{
    public class OrderDTO
    {
        public Guid OrderId { get; set; }
        public CustomerDTO Customer { get; set; }
        public DeliveryPersonDTO DeliveryPerson { get; set; }
        public RestaurantDTO Restaurant { get; set; }

        [ValidateOrderStatus]
        public string OrderStatus { get; set; }
        public List<ItemDTO> Items { get; set; }
        public List<string> ValidStatuses { get; set; }
    }
}





