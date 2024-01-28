using FoodDeliveryAPI.Exceptions;
using FoodDeliveryAPI.Models;
using FoodDeliveryAPI.Service;
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
        [HttpPost]
        public async Task<ActionResult<Customer>> AddCustomer(Customer customer) 
        {
            try
            {
                return Accepted(await _customerService.AddCustomer(customer));
            }
            catch (InvalidValueException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
