using AutoMapper;
using FoodDeliveryAPI.DataAcces.Data;
using FoodDeliveryAPI.Domain.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Domain.Service
{
    public class ItemService : IItemService
    {
        private FoodDeliveryAPIContext _context;
        private IMapper _mapper;
        public ItemService(FoodDeliveryAPIContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ItemDTO>> GetAllItems()
        {
            return await _context.Items.Select(e=>_mapper.Map<ItemDTO>(e)).ToListAsync();
        }
    }
}
