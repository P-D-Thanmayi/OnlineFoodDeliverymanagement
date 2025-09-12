using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Repositories;
using Domain.Models;
using FoodDeliveryProject.DTO;
using FoodDeliveryProject.Repositories;
using Domain.DTO;
namespace FoodDeliveryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser userServices;
        

        public UserController(IUser userServices)
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
        [HttpGet]
        public ActionResult<List<UserDto>> getUsers()
        {
            var users=userServices.getUsers();
            return Ok(users);
        }


        [HttpPost]
        public ActionResult<UserDto> CreateUser([FromBody] CreateUserDto userDto)
        {
            if (!ModelState.IsValid) { 
                return BadRequest(ModelState);
            }   
            var createdUser=userServices.CreateUser(userDto);
            return Ok(createdUser);
        }
        [HttpGet]
        [Route("{role}")]
        public ActionResult<List<UserDto>> getUsersByRole(string role)
        {
            var usersWithThatRole = userServices.getUsersByRole(role);
            return Ok(usersWithThatRole);
        }
    }
}
