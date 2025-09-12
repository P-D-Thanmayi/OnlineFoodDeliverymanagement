﻿using Domain.DTO;
using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FoodDeliveryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _order;

        public OrderController(IOrder order)
        {
            _order = order;
        }


        [HttpPost("AddingordersbyId")]
        public IActionResult AddingOrder([FromBody] AddOrderDto dto)
        {
            if (dto.UserId <= 0 || dto.RestaurantId <= 0)
            {
                return BadRequest("Invalid order data.");
            }

            _order.AddOrder(dto);
            return Ok("Order added successfully.");
        }




        [HttpGet("GetOrderbyorderId/{id}")]
        public IActionResult GetOrderByOrderId(int id)
        {
            var order = _order.GetOrderByOrderId(id);

            if (order == null)
                return NotFound("Order not found.");

            return Ok(order);
        }

    }
}
