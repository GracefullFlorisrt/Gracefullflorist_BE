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
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductController(ProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            try
            {
                var Product = await _service.GetAllProduct();
                return Ok(Product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string Productid)
        {
            var Product = await _service.GetProductByID(Productid);
            if (Product == null)
            {
                return NotFound();
            }
            return Ok(Product);
        }


        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product Product)
        {
            if (Product == null)
            {
                return BadRequest("Product object is null");
            }

            try
            {
                await _service.AddProduct(Product);
                return Ok("Product added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(string Productid, [FromBody] Product Product)
        {
            if (Product == null || Product.ProductId != Productid)
            {
                return BadRequest("Product data is invalid");
            }

            try
            {
                await _service.UpdateProduct(Product);
                return Ok("Product updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string Productid)
        {
            try
            {
                await _service.DeleteProduct(Productid);
                return Ok("Product deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
