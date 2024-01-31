using Microsoft.EntityFrameworkCore;
using FoodDeliveryAPI.DataAcces.Data;
using FoodDeliveryAPI.DataAcces.Models;
using FoodDeliveryAPI.Domain.Exceptions;
using FoodDeliveryAPI.Domain.DTO;
using AutoMapper;

namespace FoodDeliveryAPI.Domain.Service
{
    public class DeliveryPersonService : IDeliveryPersonService
    {
        private FoodDeliveryAPIContext _context;
        private IMapper _mapper;
        public  DeliveryPersonService(FoodDeliveryAPIContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DeliveryPersonDTO> AddDeliveryPerson(DeliveryPerson deliveryPerson)
        {
            if(deliveryPerson != null)
            {
                await _context.DeliveryPersons.AddAsync(deliveryPerson);
                await _context.SaveChangesAsync();
                return _mapper.Map<DeliveryPersonDTO>(deliveryPerson);
            }
            throw new InvalidValueException("deliveryPerson can't be null");
        }

        public async Task<List<DeliveryPersonDTO>> GetAllDeliveryPersons()
        {
            var deliveryPersons =  await _context.DeliveryPersons.ToListAsync();
            return deliveryPersons
                    .Select(deliveryPerson=>
                        _mapper
                        .Map<DeliveryPersonDTO>(deliveryPerson))
                        .ToList();
        }

        public async Task<DeliveryPersonDTO> GetDeliveryPersonById(Guid deliveryPersonId)
        {
            return _mapper.Map<DeliveryPersonDTO>(await _context.DeliveryPersons.Include(e=>e.AllOrders).FirstOrDefaultAsync(e=>e.UserId==deliveryPersonId) ?? throw new NoDeliveyPersonFoundException($"Can't find any deliveryperson with id {deliveryPersonId}"));
        }
    }
}
