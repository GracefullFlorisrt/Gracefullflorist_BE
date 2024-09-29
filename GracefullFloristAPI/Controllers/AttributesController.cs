using BusinessObj.Models;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class AttributesController : ControllerBase
    {
        private readonly AttributeService _service;

        public AttributesController(AttributeService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [Route("All")]
        [HttpGet]
        public async Task<IActionResult> GetAllAttributes()
        {
            try
            {
                var attributes = await _service.GetAllAttribute();
                return Ok(attributes); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [AllowAnonymous]
        [Route("ID")]
        [HttpGet]
        public async Task<IActionResult> GetAttributeById(string id)
        {
            var attribute = await _service.GetAttributeByID(id);
            if (attribute == null)
            {
                return NotFound(); 
            }
            return Ok(attribute); 
        }

        [AllowAnonymous]
        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> AddAttribute([FromBody] BusinessObj.Models.Attribute attribute)
        {
            if (attribute == null)
            {
                return BadRequest("Attribute object is null"); 
            }

            try
            {
                await _service.AddAttribute(attribute);
                return Ok("Attribute added successfully"); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [Authorize(Roles = "2,3")]
        [Route("Update")]
        [HttpPut]
        public async Task<IActionResult> UpdateAttribute(string id, [FromBody] BusinessObj.Models.Attribute attribute)
        {
            if (attribute == null || attribute.AttributeId != id)
            {
                return BadRequest("Attribute data is invalid");
            }

            try
            {
                await _service.UpdateAttribute(attribute);
                return Ok("Attribute updated successfully"); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [Authorize(Roles = "2,3")]
        [Route("Delete")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAttribute(string id)
        {
            try
            {
                await _service.DeleteAttribute(id);
                return Ok("Attribute deleted successfully"); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
