using Domain.DTO;
using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurant restaurant;
        public RestaurantController(IRestaurant restaurant)
        {
            this.restaurant=restaurant;
        }


        [HttpGet]
        public IActionResult GetRestaurants()
        {
            var restaurants=restaurant.GetRestaurants();
            if(restaurants == null)
            {
                return NotFound();
            }
            return Ok(restaurants);
        }
        [HttpPost]
        public IActionResult AddRestaurant([FromBody] RestaurantCreateDto restaurantCreateDto)
        {
            var created = restaurant.AddRestaurant(restaurantCreateDto);
            if (created == null)
            {
                return BadRequest("");
            }
            return Ok(created);


        }
       

    }
}
