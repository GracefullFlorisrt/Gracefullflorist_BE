﻿using BusinessObj.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _service;

        public OrderController(OrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrder()
        {
            try
            {
                var Order = await _service.GetAllOrder();
                return Ok(Order);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(string orderid)
        {
            var Order = await _service.GetOrderByID(orderid);
            if (Order == null)
            {
                return NotFound();
            }
            return Ok(Order);
        }


        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] Order Order)
        {
            if (Order == null)
            {
                return BadRequest("Order object is null");
            }

            try
            {
                await _service.AddOrder(Order);
                return Ok("Order added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(string orderid, [FromBody] Order Order)
        {
            if (Order == null || Order.OrderId != orderid )
            {
                return BadRequest("Order data is invalid");
            }

            try
            {
                await _service.UpdateOrder(Order);
                return Ok("Order updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(string orderid)
        {
            try
            {
                await _service.DeleteOrder(orderid);
                return Ok("Order deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
