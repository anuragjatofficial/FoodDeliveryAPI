
using FoodDeliveryAPI.DataAcces.Models;
using FoodDeliveryAPI.Domain.DTO;

namespace FoodDeliveryAPI.Domain.Service
{
    public interface IDeliveryPersonService
    {
        Task<DeliveryPersonDTO> GetDeliveryPersonById(Guid deliveryPersonId);
        Task<List<DeliveryPersonDTO>> GetAllDeliveryPersons();
        Task<DeliveryPersonDTO> AddDeliveryPerson(DeliveryPerson deliveryPerson);
    }
}
