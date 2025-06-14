using FoodDeliveryAPI.DataAcces.Models;
using FoodDeliveryAPI.Domain.Exceptions;
using FoodDeliveryAPI.Domain.Service;
using FoodDeliveryAPI.Domain.DTO;
using FoodDeliveryAPI.Domain.Validations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

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

        [HttpPost("customer/{customerId}")]
        [Authorize(Roles = $"{Role.USER},{Role.SUPER_ADMIN},{Role.ADMIN}")]
        public async Task<ActionResult<OrderDTO>> PlaceOrder(Guid customerId)
        {
            try
            {
                return Created("/Order", await _orderService.PlaceOrder(customerId));
            }catch (Exception ex)
            {
                 return BadRequest(ex.Message);
            }
        }

        [HttpPatch("update/{orderId}")]
        [Authorize(Roles = $"{Role.ADMIN},{Role.SUPER_ADMIN},{Role.DELIVERY_PERSON}")]
        public async Task<ActionResult<string>> UpdateStatus(Guid orderId,[ValidateOrderStatus]string status)
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
        public async Task<ActionResult<OrderDTO>> GetAllOrders(
            [FromQuery]
            int page = 1,
            // to take the item per page
            [FromQuery]
            int pageSize = 10
        )
        {
            return Ok(await _orderService.GetAllOrders(page,pageSize));
        }

        [HttpGet("{id}")]

        [Authorize(Roles = $"{Role.ADMIN},{Role.SUPER_ADMIN}")]
        public async Task<ActionResult<OrderDTO>> GetOrderById(Guid id)
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