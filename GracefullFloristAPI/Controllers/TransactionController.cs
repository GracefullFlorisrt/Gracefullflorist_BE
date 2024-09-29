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
    public class TransactionController : ControllerBase
    {
        private readonly TransactionService _service;

        public TransactionController(TransactionService service)
        {
            _service = service;
        }

        [Authorize(Roles = "1")]
        [Route("All")]
        [HttpGet]
        public async Task<IActionResult> GetAllTransaction()
        {
            try
            {
                var Transaction = await _service.GetAllTransaction();
                return Ok(Transaction);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [Authorize(Roles = "1")]
        [Route("ID")]
        [HttpGet]
        public async Task<IActionResult> GetTransactionById(string Transactionid)
        {
            var Transaction = await _service.GetTransactionByID(Transactionid);
            if (Transaction == null)
            {
                return NotFound();
            }
            return Ok(Transaction);
        }


        [Authorize(Roles = "2,3")]
        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> AddTransaction([FromBody] Transaction Transaction)
        {
            if (Transaction == null)
            {
                return BadRequest("Transaction object is null");
            }

            try
            {
                await _service.AddTransaction(Transaction);
                return Ok("Transaction added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize(Roles = "2,3")]
        [Route("Update")]
        [HttpPut]
        public async Task<IActionResult> UpdateTransaction(string Transactionid, [FromBody] Transaction Transaction)
        {
            if (Transaction == null || Transaction.TransactionId != Transactionid)
            {
                return BadRequest("Transaction data is invalid");
            }

            try
            {
                await _service.UpdateTransaction(Transaction);
                return Ok("Transaction updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize(Roles = "2,3")]
        [Route("Delete")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTransaction(string Transactionid)
        {
            try
            {
                await _service.DeleteTransaction(Transactionid);
                return Ok("Transaction deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
