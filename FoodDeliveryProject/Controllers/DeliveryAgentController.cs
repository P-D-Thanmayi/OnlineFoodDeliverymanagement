using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Domain.DTO;

namespace FoodDeliveryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryAgentController : ControllerBase
    {
        private readonly DeliveryAgentService _deliveryAgentService;
        public DeliveryAgentController()
        {
            _deliveryAgentService=new DeliveryAgentService();
        }

        //for delivery agent
        [HttpGet("AllDeliveriesByAgent/{AgentId}")]
        public ActionResult<List<Delivery>> GetDeliveriesByAgentId(int AgentId)
        {
            var deliveries = _deliveryAgentService.GetDeliveriesByAgentId(AgentId);
            if (deliveries == null)
            {
                return NotFound($"No delivery found for Agent ID: {AgentId}");
            }
            return Ok(deliveries);
        }

        //for delivery agent
        [HttpPut("UpdateDeliveryStatus")]
        public ActionResult UpdateDeliveryStatus(int DeliveryId)
        {
            var status = _deliveryAgentService.UpdateDeliveryStatus(DeliveryId);
            if (!status)
            {
                return BadRequest("");
            }
            return Ok(status);
        }
    }
}
