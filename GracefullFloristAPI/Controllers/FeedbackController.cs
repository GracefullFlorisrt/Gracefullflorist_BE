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
    public class FeedbackController : ControllerBase
    {
        private readonly FeedbackService _service;

        public FeedbackController(FeedbackService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFeedback()
        {
            try
            {
                var Feedback = await _service.GetAllFeedback();
                return Ok(Feedback);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeedbackById(string id)
        {
            var Feedback = await _service.GetFeedbackByID(id);
            if (Feedback == null)
            {
                return NotFound();
            }
            return Ok(Feedback);
        }


        [HttpPost]
        public async Task<IActionResult> AddFeedback([FromBody] Feedback Feedback)
        {
            if (Feedback == null)
            {
                return BadRequest("Feedback object is null");
            }

            try
            {
                await _service.AddFeedback(Feedback);
                return Ok("Feedback added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFeedback(string id, [FromBody] Feedback Feedback)
        {
            if (Feedback == null || Feedback.FeedbackId != id)
            {
                return BadRequest("Feedback data is invalid");
            }

            try
            {
                await _service.UpdateFeedback(Feedback);
                return Ok("Feedback updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedback(string id)
        {
            try
            {
                await _service.DeleteFeedback(id);
                return Ok("Feedback deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
