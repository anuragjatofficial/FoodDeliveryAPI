using FoodDeliveryAPI.Data;
using FoodDeliveryAPI.Exceptions;
using FoodDeliveryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryAPI.Service
{
    public class DeliveryPersonService : IDeliveryPersonService
    {
        private FoodDeliveryAPIContext _context;

        public  DeliveryPersonService(FoodDeliveryAPIContext context)
        {
            _context = context;
        }

        public async Task<DeliveryPerson> AddDeliveryPerson(DeliveryPerson deliveryPerson)
        {
            if(deliveryPerson != null)
            {
                await _context.DeliveryPersons.AddAsync(deliveryPerson);
                await _context.SaveChangesAsync();
                return deliveryPerson;
            }
            throw new InvalidValueException("deliveryPerson can't be null");
        }

        public async Task<List<DeliveryPerson>> GetAllDeliveryPersons()
        {
            return await _context.DeliveryPersons.ToListAsync();
        }

        public async Task<DeliveryPerson> GetDeliveryPersonById(Guid deliveryPersonId)
        {
            return await _context.DeliveryPersons.Include(e=>e.AllOrders).FirstOrDefaultAsync(e=>e.UserId==deliveryPersonId) ?? throw new NoDeliveyPersonFoundException($"Can't find any deliveryperson with id {deliveryPersonId}");
        }
    }
}
