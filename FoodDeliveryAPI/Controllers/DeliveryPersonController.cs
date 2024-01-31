using FoodDeliveryAPI.DataAcces.Models;
using FoodDeliveryAPI.Domain.DTO;
using FoodDeliveryAPI.Domain.Exceptions;
using FoodDeliveryAPI.Domain.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DeliveryPersonController : ControllerBase
    {
        private IDeliveryPersonService _deliveryPersonService;

        private IOrderService _orderService;

        public DeliveryPersonController (IDeliveryPersonService deliveryPersonService,IOrderService orderService)
        {
            _deliveryPersonService = deliveryPersonService;
            _orderService = orderService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<DeliveryPersonDTO>> AddDeliveryPerson(UserDTO user)
        {
            try
            {
                return Created("/deliveryperson",await _deliveryPersonService
                    .AddDeliveryPerson(new DeliveryPerson()
                    {
                        UserEmail = user.UserEmail,
                        UserName = user.UserName,
                        Password = user.Password,
                        CreatedAt = DateTime.Now,
                        Role = Role.DELIVERY_PERSON,
                    })
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = $"{Role.ADMIN},{Role.SUPER_ADMIN}")]
        public async Task<ActionResult<DeliveryPersonDTO>> GetDeliveryPersonById(Guid id)
        {
            try
            {
                return Ok(await _deliveryPersonService.GetDeliveryPersonById(id));
            }
            catch(NoDeliveyPersonFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = $"{Role.ADMIN},{Role.SUPER_ADMIN}")]
        public async Task<ActionResult<List<DeliveryPersonDTO>>> GetAllDeliveryPersons()
        {
            try
            {
               return Ok(await _deliveryPersonService.GetAllDeliveryPersons());
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("orders/active")]
        [Authorize(Roles=$"{Role.DELIVERY_PERSON},{Role.SUPER_ADMIN},{Role.ADMIN}")]
        public async Task<ActionResult<List<OrderDTO>>> GetActiveOrders(Guid userId)
        {
            return Ok(await _orderService.GetActiveOrders(userId));
        }

    }
}
