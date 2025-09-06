using EquityPositionTrackerAPI.Models;
using EquityPositionTrackerAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EquityPositionTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITradeProcessor _tradeProcessor;

        public TransactionController(ITradeProcessor tradeProcessor)
        {
            _tradeProcessor = tradeProcessor;
        }

        [HttpPost]
        public IActionResult SubmitTransaction([FromBody] Transaction transaction)
        {
            try
            {
                _tradeProcessor.ProcessTransaction(transaction);
                return Ok("Transaction processed successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("/api/positions")]
        public IActionResult GetPositions()
        {
            var positions = _tradeProcessor.GetAllPositions();
            return Ok(positions);
        }
    }
}
