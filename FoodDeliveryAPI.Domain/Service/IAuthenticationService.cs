<<<<<<< HEAD:FoodDeliveryAPI.Domain/Service/IAuthenticationService.cs
﻿using FoodDeliveryAPI.DataAcces.Models;
using FoodDeliveryAPI.Domain.DTO;

namespace FoodDeliveryAPI.Domain.Service
=======
﻿using FoodDeliveryAPI.DTO;
using FoodDeliveryAPI.Models;

namespace FoodDeliveryAPI.Service
>>>>>>> 77c3c8d3869beb5d7929c4f1d13c2e05bd9b2655:FoodDeliveryAPI/Service/IAuthenticationService.cs
{   
    public interface IAuthenticationService
    {
        Token GenerateToken(User user);
        User AuthenticateCustomer(UserCredentials credentials);
        User AuthenticateDeliveryPerson(UserCredentials credentials);
        User AuthenticateAdmin(UserCredentials userCredentials);
    }
}
