using FoodDeliveryAPI.Domain.DTO;
using FoodDeliveryAPI.Domain.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {

        private IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<ActionResult<ItemDTO>> getAllItems()
        {
            return Ok(await _itemService.GetAllItems());
        }
    }
}
