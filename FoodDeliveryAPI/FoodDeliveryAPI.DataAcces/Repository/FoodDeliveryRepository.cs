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
    public class FoodDeliveryRepository<T> : IRepository<T> where T : class
    {
        private readonly FoodDeliveryAPIContext _context;

        public FoodDeliveryRepository(FoodDeliveryAPIContext context)
        {
            _context = context;
        }

        public async Task<T> Add(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

    }
}
