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
        public CustomerController (ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [Authorize(Roles =$"{Role.ADMIN},{Role.SUPER_ADMIN}")]
        [HttpGet("{Id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(string Id)
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
        public ActionResult<IEnumerable<Customer>> GetAllCustomers()
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
        public async Task<ActionResult<Customer>> AddCustomer(CustomerDTO customer) 
        {
            try
            {
                return Accepted(
                    await _customerService
                            .AddCustomer(
                                new Customer() {
                                    UserName=customer.UserName,
                                    UserEmail=customer.UserEmail,
                                    Password=customer.Password,
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

    }
}
