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
    public class EntertainController : ControllerBase
    {
        private readonly EntertainService _service;

        public EntertainController(EntertainService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEntertain()
        {
            try
            {
                var Entertain = await _service.GetAllEntertain();
                return Ok(Entertain);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntertainById(string id)
        {
            var Entertain = await _service.GetEntertainByID(id);
            if (Entertain == null)
            {
                return NotFound();
            }
            return Ok(Entertain);
        }


        [HttpPost]
        public async Task<IActionResult> AddEntertain([FromBody] Entertain Entertain)
        {
            if (Entertain == null)
            {
                return BadRequest("Entertain object is null");
            }

            try
            {
                await _service.AddEntertain(Entertain);
                return Ok("Entertain added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEntertain(string id, [FromBody] Entertain Entertain)
        {
            if (Entertain == null || Entertain.EnId != id)
            {
                return BadRequest("Entertain data is invalid");
            }

            try
            {
                await _service.UpdateEntertain(Entertain);
                return Ok("Entertain updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntertain(string id)
        {
            try
            {
                await _service.DeleteEntertain(id);
                return Ok("Entertain deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
