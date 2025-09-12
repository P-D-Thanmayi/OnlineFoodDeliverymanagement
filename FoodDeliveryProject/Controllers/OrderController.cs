
using Domain.Models;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderServices _order;

        public OrderController(OrderServices order)
        {
            _order = order;
        }


        [HttpPost("AddingordersbyId/{userid}/{restaurantid}")]
        public IActionResult AddingOrder(int userId, int restaurantId)
        {
            if (userId <= 0 || restaurantId <= 0)
            {
                return BadRequest("Invalid order data.");
            }

            _order.AddOrder(userId, restaurantId);
            return Ok("Order added successfully.");
        }


        [HttpGet("GetOrderbyUserId /{Id} ")]
        public IActionResult GetOrderByUserId(int id)
        {
            IEnumerable<Order> orders = _order.GetOrderByUserId(id);
            return Ok(orders);

        }


        [HttpGet("GetOrderbyrestaurantId /{Id} ")]
        public IActionResult GetOrderByrestaurantId(int id)
        {
            IEnumerable<Order> orders = _order.GetOrderByRestaurantId(id);
            return Ok(orders);

        }

        [HttpGet("GetOrderbyorderId /{Id} ")]
        public IActionResult GetOrderByorderId(int id)
        {
            IEnumerable<Order> orders = _order.GetOrderByOrderId(id);
            return Ok(orders);

        }



    }
}
