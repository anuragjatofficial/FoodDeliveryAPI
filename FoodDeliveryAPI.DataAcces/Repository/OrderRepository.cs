using FoodDeliveryAPI.DataAcces.Data;
using FoodDeliveryAPI.DataAcces.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.DataAcces.Repository
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly FoodDeliveryAPIContext _context;

        public OrderRepository(FoodDeliveryAPIContext context)
        {
            _context = context;
        }

        public async Task<Order> Add(Order entity)
        {
           await _context.Orders.AddAsync(entity);
           await _context.SaveChangesAsync();
           return entity;
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetById(Guid id)
        {
            return await _context.Orders.FirstOrDefaultAsync(o=>o.OrderId == id);
        }
    }
}
