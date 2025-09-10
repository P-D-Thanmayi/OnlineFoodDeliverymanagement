using FoodDeliveryProject.Models;
using FoodDeliveryProject.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly OrderItemService _fooditems;
        public OrderItemController(OrderItemService foodItems)
        {
            _fooditems=foodItems;
        }

        [HttpGet("getfooditemsbyid/{id}")]
        public IActionResult GetFoodByOrder(int id)
        {
            IEnumerable<FoodItem> fooditem = _fooditems.GetFoodByOrderId(id);
            return Ok(fooditem);
        }

    }
}
