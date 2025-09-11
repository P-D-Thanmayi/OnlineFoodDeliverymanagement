using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Repositories;
using Domain.Models;
using FoodDeliveryProject.DTO;
using Infrastructure.Interfaces;
namespace FoodDeliveryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userServices;
        

        public UserController(IUserRepository userServices)
        {
            this.userServices = userServices;
        }

        //[HttpGet("getusers/{id}")]
        //public IActionResult GetAllUsers(int id)
        //{
        //    IEnumerable<Address> address = userServices.GetAddressesByUserId(id);
        //    return Ok(address);
        //}
        //[HttpGet("getorders/{id}")]
        //public IActionResult GetOrdersByUser(int id)
        //{
        //    IEnumerable<Order> orders = userServices.GetOrdersByUserId(id);
        //    return Ok(orders);
        //}



        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid) { 
                return BadRequest(ModelState);
            }   
            var createdUser=userServices.CreateUser(userDto);
            return Ok(createdUser);
        }
    }
}
