
using FoodDeliveryAPI.DataAcces.Models;

namespace FoodDeliveryAPI.Domain.Service
{
    public interface IDeliveryPersonService
    {
        Task<DeliveryPerson> GetDeliveryPersonById(Guid deliveryPersonId);
        Task<List<DeliveryPerson>> GetAllDeliveryPersons();
        Task<DeliveryPerson> AddDeliveryPerson(DeliveryPerson deliveryPerson);
    }
}
