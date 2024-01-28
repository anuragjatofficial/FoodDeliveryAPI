using FoodDeliveryAPI.Data;
using FoodDeliveryAPI.Exceptions;
using FoodDeliveryAPI.Models;
using FoodDeliveryAPI.Service;
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
        public async Task<ActionResult<DeliveryPerson>> AddDeliveryPerson(DeliveryPerson deliveryPerson)
        {
            try
            {
                return Created("/deliveryperson",await _deliveryPersonService.AddDeliveryPerson(deliveryPerson));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")] 
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
