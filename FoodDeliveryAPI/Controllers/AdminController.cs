using FoodDeliveryAPI.DataAcces.Models;
using FoodDeliveryAPI.Domain.DTO;
using FoodDeliveryAPI.Domain.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<Admin> CreateAdmin(AdminDTO admin)
        {
            try
            {
                return Created("/admin", _adminService.CreateAdmin(new Admin()
                {
                    CreatedAt = DateTime.Now,
                    Password = admin.Password,
                    Role = Role.ADMIN,
                    UserEmail = admin.UserEmail,
                    UserName = admin.UserName,
                }));
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 
    }
}
