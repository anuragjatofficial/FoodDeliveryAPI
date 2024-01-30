<<<<<<< HEAD:FoodDeliveryAPI.Domain/DTO/Token.cs
﻿namespace FoodDeliveryAPI.Domain.DTO
=======
﻿namespace FoodDeliveryAPI.DTO
>>>>>>> 77c3c8d3869beb5d7929c4f1d13c2e05bd9b2655:FoodDeliveryAPI/DTO/Token.cs
{
    public class Token
    {
        public string authToken {  get; set; }
        public DateTime IssuedAt { get; set; }
        public DateTime ExpireAt { get; set; }
    }
}
