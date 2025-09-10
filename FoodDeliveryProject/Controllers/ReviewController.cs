

using Infrastructure.Repositories;

using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryProject.Controllers

{

    [Route("api/[controller]")]

    [ApiController]

    public class ReviewController : ControllerBase

    {

        private readonly ReviewService _rating;

        public ReviewController(ReviewService rating)

        {

            _rating = rating;

        }

        [HttpGet("GetReviewbyRestaurant /{restaurantName}")]

        public IActionResult GetReviewsByRestaurant(string restaurantName)

        {

            decimal reviews = _rating.GetAverageRatingByRestaurantName(restaurantName);

            return Ok(reviews);

        }

        [HttpGet("Getrestaurantbyrating/{id}")]

        public IActionResult GetrestaurantbyRating(decimal id)

        {

            IEnumerable<string> restaurants = _rating.GetRestaurantNameByRating(id).ToList();

            return Ok(restaurants);

        }

    }

}

