using FoodDeliveryAPI.Data;
using FoodDeliveryAPI.Exceptions;
using FoodDeliveryAPI.Models;

namespace FoodDeliveryAPI.Service
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
