using BusinessObj.Models;
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
    public class OrderDetailController : ControllerBase
    {
        private readonly OrderDetailService _service;

        public OrderDetailController(OrderDetailService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrderDetail()
        {
            try
            {
                var OrderDetail = await _service.GetAllOrderDetail();
                return Ok(OrderDetail);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailById(string orderid, string productid)
        {
            var OrderDetail = await _service.GetOrderDetailByID(orderid, productid);
            if (OrderDetail == null)
            {
                return NotFound();
            }
            return Ok(OrderDetail);
        }


        [HttpPost]
        public async Task<IActionResult> AddOrderDetail([FromBody] OrderDetail OrderDetail)
        {
            if (OrderDetail == null)
            {
                return BadRequest("OrderDetail object is null");
            }

            try
            {
                await _service.AddOrderDetail(OrderDetail);
                return Ok("OrderDetail added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderDetail(string orderid, string productid, [FromBody] OrderDetail OrderDetail)
        {
            if (OrderDetail == null || OrderDetail.OrderId != orderid || OrderDetail.ProductId != productid)
            {
                return BadRequest("OrderDetail data is invalid");
            }

            try
            {
                await _service.UpdateOrderDetail(OrderDetail);
                return Ok("OrderDetail updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail(string orderid, string productid)
        {
            try
            {
                await _service.DeleteOrderDetail(orderid, productid);
                return Ok("OrderDetail deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
