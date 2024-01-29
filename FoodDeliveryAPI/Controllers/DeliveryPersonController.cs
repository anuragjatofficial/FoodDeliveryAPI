using FoodDeliveryAPI.Data;
using FoodDeliveryAPI.DTO;
using FoodDeliveryAPI.Exceptions;
using FoodDeliveryAPI.Models;
using FoodDeliveryAPI.Service;
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
        public DeliveryPersonController (IDeliveryPersonService deliveryPersonService)
        {
            _deliveryPersonService = deliveryPersonService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<DeliveryPerson>> AddDeliveryPerson(DeliveryPersonDTO deliveryPerson)
        {
            try
            {
                return Created("/deliveryperson",await _deliveryPersonService
                    .AddDeliveryPerson(new DeliveryPerson()
                    {
                        UserEmail = deliveryPerson.UserEmail,
                        UserName = deliveryPerson.UserName,
                        Password = deliveryPerson.Password,
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
        public async Task<ActionResult<DeliveryPerson>> GetDeliveryPersonById(Guid id)
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
        public async Task<ActionResult<List<DeliveryPerson>>> GetAllDeliveryPersons()
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



    }
}
