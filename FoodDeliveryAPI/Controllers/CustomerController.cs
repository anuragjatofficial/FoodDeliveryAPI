using FoodDeliveryAPI.DataAcces.Models;
using FoodDeliveryAPI.Domain.DTO;
using FoodDeliveryAPI.Domain.Exceptions;
using FoodDeliveryAPI.Domain.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;
        private IOrderService _orderService;
        public CustomerController (ICustomerService customerService,IOrderService orderService)
        {
            _customerService = customerService;
            _orderService = orderService;
        }

        [Authorize(Roles =$"{Role.ADMIN},{Role.SUPER_ADMIN}")]
        [HttpGet("{Id}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomerById(string Id)
        {
            try
            {
                return Ok(await _customerService.GetCustomerById(Id));
            }
            catch (CustomerNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = $"{Role.ADMIN},{Role.SUPER_ADMIN}")]
        public ActionResult<IEnumerable<CustomerDTO>> GetAllCustomers()
        {
            try
            {
                return Ok(_customerService.GetAllCustomers());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("/signup")]
        [AllowAnonymous]
        public async Task<ActionResult<CustomerDTO>> AddCustomer(UserDTO user) 
        {
            try
            {
                return Accepted(
                    await _customerService
                            .AddCustomer(
                                new Customer() {
                                    UserName= user.UserName,
                                    UserEmail= user.UserEmail,
                                    Password=user.Password,
                                    Role=Role.USER,
                                    CreatedAt=DateTime.Now 
                                }
                              )
                );
            }
            catch (InvalidValueException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("orders/active")]
        [Authorize(Roles = $"{Role.ADMIN},{Role.SUPER_ADMIN},{Role.USER}")]
        public async Task<ActionResult<List<OrderDTO>>> GetActiveOrders(Guid customerId) => 
            Ok(await _orderService.GetActiveOrders(customerId));


    }
}
