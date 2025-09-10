using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using Domain.Models;

namespace FoodDeliveryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AdminService adminService;

        public AdminController(AdminService adminService)
        {
            this.adminService = adminService;
        }

        [HttpGet("allrestaurents")]
        public IActionResult GetRestaurantsByRole()
        {
              IEnumerable<User> restaurant= adminService.GetRestaurantByRole();
            if(restaurant == null || !restaurant.Any())
                return Ok(restaurant);
            return NotFound("No restaurants found with the specified role.");
        }


        [HttpGet("alldeliveryagents")]
        public IActionResult GetDeliveryAgentsByRole()
        {
            IEnumerable<User> deliveryAgents = adminService.GetDeliveryAgentByRole();
            if (deliveryAgents == null || !deliveryAgents.Any())
                return Ok(deliveryAgents);
            return NotFound("No delivery agents found with the specified role.");
        }

        [HttpGet("allCustomers")]
        public IActionResult GetCustomersByRole()
        {
            IEnumerable<User> customers = adminService.GetCustomerByRole();
            if (customers == null || !customers.Any())
                return Ok(customers);
            return NotFound("No customers found with the specified role.");
        }

        [HttpGet("allrestaurents/{role}")]
        
        public IActionResult GetByRole(string role) { 
            IEnumerable<User> users = adminService.GetUserByRole(role);
            if (users == null)
                return Ok(users);
            return NotFound("Not Found");
        }
    }
}
