using FoodDeliveryAPI.DataAcces.Models;
using FoodDeliveryAPI.Domain.DTO;

namespace FoodDeliveryAPI.Domain.Service
{   
    public interface IAuthenticationService
    {
        Token GenerateToken(User user);
        User AuthenticateCustomer(UserCredentials credentials);
        User AuthenticateDeliveryPerson(UserCredentials credentials);
        User AuthenticateAdmin(UserCredentials userCredentials);
    }
}
