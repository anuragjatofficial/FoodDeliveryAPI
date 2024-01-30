<<<<<<< HEAD:FoodDeliveryAPI.Domain/Service/AdminService.cs
﻿
using FoodDeliveryAPI.DataAcces.Data;
using FoodDeliveryAPI.DataAcces.Models;
using FoodDeliveryAPI.Domain.Exceptions;

namespace FoodDeliveryAPI.Domain.Service
=======
﻿using FoodDeliveryAPI.Data;
using FoodDeliveryAPI.Exceptions;
using FoodDeliveryAPI.Models;

namespace FoodDeliveryAPI.Service
>>>>>>> 77c3c8d3869beb5d7929c4f1d13c2e05bd9b2655:FoodDeliveryAPI/Service/AdminService.cs
{
    public class AdminService : IAdminService
    {
        private readonly FoodDeliveryAPIContext _context;

        public AdminService(FoodDeliveryAPIContext context)
        {
            _context = context;
        }

        public Admin CreateAdmin(Admin admin)
        {
            if(admin!=null)
            {
                _context.Admins.Add(admin);
                _context.SaveChanges();
                return admin;
            }
            throw new InvalidValueException("admin can't be null");
        }
    }
}
