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

        private readonly ILogger<AdminController> _logger;

        public AdminController(IAdminService adminService, ILogger<AdminController> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<Admin> CreateAdmin(UserDTO user)
        {
            _logger.LogInformation("{@user}",user);

            try
            {
                _logger.LogInformation($"executed create admin method");

                return Created("/admin", _adminService.CreateAdmin(new Admin()
                {
                    CreatedAt = DateTime.Now,
                    Password = user.Password,
                    Role = Role.ADMIN,
                    UserEmail = user.UserEmail,
                    UserName = user.UserName,
                }));

            }catch (Exception ex)
            {
                _logger.LogError("{@ex}",ex);
                return BadRequest(ex.Message);
            }
        } 
    
    }
}
