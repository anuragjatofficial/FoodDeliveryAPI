using FoodDeliveryAPI.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Domain.Service
{
    public interface IItemService
    {
        Task<List<ItemDTO>> GetAllItems();
    }
}
