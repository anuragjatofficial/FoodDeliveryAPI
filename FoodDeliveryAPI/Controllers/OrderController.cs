using FoodDeliveryAPI.Exceptions;
using FoodDeliveryAPI.Input;
using FoodDeliveryAPI.Models;
using FoodDeliveryAPI.Service;
using FoodDeliveryAPI.Validations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Authorize(Roles = $"{Role.USER},{Role.SUPER_ADMIN},{Role.ADMIN}")]
        public async Task<ActionResult<Order>> PlaceOrder([FromBody] OrderDTO order)
        {
            try
            {
                return Created("/Order", await _orderService.PlaceOrder(order));
            }catch (Exception ex)
            {
                 return BadRequest(ex.Message);
            }
        }

        [HttpPatch("update/{orderId}")]
        [Authorize(Roles = $"{Role.ADMIN},{Role.SUPER_ADMIN},{Role.DELIVERY_PERSON}")]
        public async Task<ActionResult<Order>> UpdateStatus(Guid orderId,[ValidateOrderStatus]string status)
        {
            try
            {
                return Accepted( await _orderService.UpdateOrderStatus(status, orderId));
            }
            catch (OrderNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles=$"{Role.ADMIN},{Role.SUPER_ADMIN}")]
        public async Task<ActionResult<Order>> GetAllOrders()
        {
            return Ok(await _orderService.GetAllOrders());
        }

        [HttpGet("{id}")]

        [Authorize(Roles = $"{Role.ADMIN},{Role.SUPER_ADMIN}")]
        public async Task<ActionResult<Order>> GetOrderById(Guid id)
        {
            try
            {
                return Ok(await _orderService.GetOrderByID(id));
            }
            catch (OrderNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}