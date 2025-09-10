using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Repositories;
using Domain.Models;
namespace FoodDeliveryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserServices _userServices;
        

        public UserController(UserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet("getusers/{id}")]
        public IActionResult GetAllUsers(int id)
        {
            IEnumerable<Address> address = _userServices.GetAddressesByUserId(id);
            return Ok(address);
        }
        [HttpGet("getorders/{id}")]
        public IActionResult GetOrdersByUser(int id)
        {
            IEnumerable<Order> orders = _userServices.GetOrdersByUserId(id);
            return Ok(orders);
        }

       

        //[HttpPost]
        //public IActionResult AddUser([FromBody] User user)
        //{
        //    _userServices.AddUser(user);
        //    return Ok("User added successfully");
        //}
    }
}
