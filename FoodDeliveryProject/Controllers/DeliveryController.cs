using Domain.Models; 
using Domain.ADO;    
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Repositories;

namespace FoodDeliveryProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryController : ControllerBase
    {
        private readonly DeliveryServices _deliveryService;

        public DeliveryController()
        {
            _deliveryService = new DeliveryServices();
        }

        [HttpGet("order/{orderId}")]
        public ActionResult<Delivery> GetDeliveryByOrderId(int orderId)
        {
            var delivery = _deliveryService.GetDeliveryByOrderId(orderId);
            if (delivery == null)
            {
                return NotFound($"No delivery found for Order ID: {orderId}");
            }
            return Ok(delivery);
        }

        [HttpGet("agent/{AgentId}")]
        public ActionResult<List<Delivery>> GetDeliveriesByAgentId(int AgentId)
        {
            var deliveries = _deliveryService.GetDeliveriesByAgentId(AgentId);
            if (deliveries == null)
            {
                return NotFound($"No delivery found for Agent ID: {AgentId}");
            }
            return Ok(deliveries);
        }

    }
}
