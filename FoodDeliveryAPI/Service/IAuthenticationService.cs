using FoodDeliveryAPI.DTO;
using FoodDeliveryAPI.Models;

namespace FoodDeliveryAPI.Service
{   
    public interface IAuthenticationService
    {
        Token GenerateToken(User user);
        User AuthenticateCustomer(UserCredentials credentials);
        User AuthenticateDeliveryPerson(UserCredentials credentials);
        User AuthenticateAdmin(UserCredentials userCredentials);
    }
}
