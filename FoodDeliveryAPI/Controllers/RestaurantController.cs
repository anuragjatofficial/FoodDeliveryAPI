using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodDeliveryAPI.DataAcces.Data;
using FoodDeliveryAPI.Domain.Service;
using FoodDeliveryAPI.Domain.Exceptions;
using FoodDeliveryAPI.Domain.DTO;
using Microsoft.AspNetCore.Authorization;
using FoodDeliveryAPI.DataAcces.Models;

namespace FoodDeliveryAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly FoodDeliveryAPIContext _context;

        private readonly IRestaurantService _restaurantService;

        public RestaurantController(FoodDeliveryAPIContext context,IRestaurantService restaurantService)
        {
            _context = context;
            _restaurantService = restaurantService;
        }

        // GET: api/Restaurant
        [HttpGet]
        [Authorize(Roles = $"{Role.ADMIN},{Role.SUPER_ADMIN}")]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurants()
        {
            try
            {
                return Ok(await _restaurantService.GetAllRestaurants());
            }
            catch(RestaurantNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Restaurant/5
        [HttpGet("{id}")]
        [Authorize(Roles = $"{Role.ADMIN},{Role.SUPER_ADMIN}")]
        public async Task<ActionResult<Restaurant>> GetRestaurant(Guid id)
        {
            try
            {
                return Ok(await _restaurantService.GetRestaurantById(id));
            }catch  (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Restaurant/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = $"{Role.ADMIN},{Role.SUPER_ADMIN}")]
        public async Task<IActionResult> PutRestaurant(Guid id, Restaurant restaurant)
        {
            if (id != restaurant.RestaurantId)
            {
                return BadRequest();
            }

            _context.Entry(restaurant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();  
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Restaurant
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<Restaurant>> PostRestaurant(RestaurantDTO restaurant)
        {
            try
            {
                return Created("api/Restaurant",await _restaurantService
                    .AddRestaurant(new Restaurant()
                    {
                        RestaurantName = restaurant.RestaurantName,
                        Address = restaurant.Address,
                        IsClosed = false,
                    })
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Restaurant/5
        [HttpDelete("{id}")]
        [Authorize(Roles = $"{Role.ADMIN},{Role.SUPER_ADMIN}")]
        public async Task<IActionResult> DeleteRestaurant(Guid id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RestaurantExists(Guid id)
        {
            return _context.Restaurants.Any(e => e.RestaurantId == id);
        }

        [HttpPatch("{RestaurantId}/status")]
        [Authorize(Roles = $"{Role.ADMIN},{Role.SUPER_ADMIN},{Role.RESTAURANT_AGENT}")]
        public async Task<ActionResult<String>> ChangeRestaurantStatus(bool status,Guid RestaurantId)
        {
            try
            {
                return await _restaurantService.ChangeRestaurantStatus(RestaurantId, status);
            }
            catch (RestaurantNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("addItems")]
        [Authorize(Roles = $"{Role.ADMIN},{Role.SUPER_ADMIN},{Role.RESTAURANT_AGENT}")]
        public async Task<ActionResult<Item>> AddItem(ItemDTO item)
        {
            try
            {
                return Created("/addItems", await _restaurantService.AddItem(item));
            }catch(RestaurantNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
            

    }
}
