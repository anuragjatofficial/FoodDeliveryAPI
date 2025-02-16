﻿using FoodDeliveryAPI.DataAcces.Models;
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
        private ILogger<CustomerController> _logger;
        public CustomerController(ICustomerService customerService, IOrderService orderService, ILogger<CustomerController> logger)
        {
            _customerService = customerService;
            _orderService = orderService;
            _logger = logger;
        }

        [Authorize(Roles = $"{Role.ADMIN},{Role.SUPER_ADMIN}")]
        [HttpGet("{Id}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomerById(string Id)
        {
            try
            {
                return Ok(await _customerService.GetCustomerById(Id));
            }
            catch (CustomerNotFoundException ex)
            {
                _logger.LogError("{@ex}", ex);
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = $"{Role.ADMIN},{Role.SUPER_ADMIN}")]
        public ActionResult<IEnumerable<CustomerDTO>> GetAllCustomers(
            // to search user by username
            [FromQuery]
            string? username,
            // for sorting on basis of field 
            [FromQuery]
            string sortBy = "username",
            // for sorting order
            [FromQuery]
            string sortOrder = "asc",
            // for taking the pageIndex
            [FromQuery]
            int page = 1,
            // to take the item per page
            [FromQuery]
            int pageSize = 10
        )
        {
            try
            {
                return Ok(_customerService.GetAllCustomers(sortBy, sortOrder, page, pageSize, username));
            }
            catch (Exception ex)
            {
                _logger.LogError("{@ex}", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("signup")]
        [AllowAnonymous]
        public async Task<ActionResult<CustomerDTO>> AddCustomer(UserDTO user)
        {
            try
            {
                return Accepted(
                    await _customerService
                            .AddCustomer(
                                new Customer()
                                {
                                    UserName = user.UserName,
                                    UserEmail = user.UserEmail,
                                    Password = user.Password,
                                    Role = Role.USER,
                                    CreatedAt = DateTime.UtcNow
                                }
                              )
                );
            }
            catch (InvalidValueException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{customerId}/orders/active")]
        [Authorize(Roles = $"{Role.ADMIN},{Role.SUPER_ADMIN},{Role.USER}")]
        public async Task<ActionResult<List<OrderDTO>>> GetActiveOrders(Guid customerId) =>
            Ok(await _orderService.GetActiveOrders(customerId));


        [HttpGet("{customerId}/orders/all")]
        [Authorize(Roles = $"{Role.ADMIN},{Role.USER},{Role.SUPER_ADMIN}")]
        public async Task<ActionResult<List<OrderDTO>>> GetAllOrders(Guid customerId)
        {
            try
            {
                return Ok(await _orderService.GetAllOrdersPlaced(customerId));
            }
            catch (CustomerNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id}/cart/add")]
        [Authorize(Roles = $"{Role.ADMIN},{Role.SUPER_ADMIN},{Role.USER}")]
        public async Task<ActionResult<List<ItemDTO>>> AddItemsToCart([FromBody] ItemDTO item, [FromRoute] Guid id)
        {
            try
            {
                return Created($"{id}/cart/add", await _customerService.addItemsToCart(item, id));
            }
            catch (ItemNotFoundException ex)
            {

                return BadRequest(ex.Message);

            }
            catch (CustomerNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}/cart")]
        public async Task<ActionResult<List<ItemDTO>>> GetCartItems(Guid id)
        {
            return Ok(await _customerService.getCartItems(id));
        }

        [HttpDelete("{userId}/cart/{itemId}")]
        [Authorize(Roles = $"{Role.ADMIN},{Role.SUPER_ADMIN},{Role.USER}")]
        public async Task<ActionResult<List<ItemDTO>>> RemoveCartItems(Guid userId, Guid itemId)
        {
            try
            {
                return Ok(await _customerService.removeItemsFromCart(itemId, userId));
            }
            catch (ItemNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (CustomerNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
