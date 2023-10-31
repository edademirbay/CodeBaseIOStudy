using CodeBaseIOStudy.Entities;
using CodeBaseIOStudy.Filter;
using CodeBaseIOStudy.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeBaseIOStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {

        private readonly IStatistics _statistics;
        public StatisticsController(IStatistics statistics)
        {
            _statistics = statistics;
        }

        [HttpGet("order/{month:int}"),Authorize]      
        public async Task<IActionResult> TotalOrder(int month)
        {
            var response = await _statistics.TotalOrder(month);
            return Ok(response);
        }

        [HttpGet("purchased/{month:int}"),Authorize]
        public async Task<IActionResult> TotalPurchased(int month)
        {
            var response = await _statistics.TotalPurchased(month);
            return Ok(response);
        }

        [HttpGet("purchasedbook/{month:int}"),Authorize]
        public async Task<IActionResult> TotalPurchasedBook(int month)
        {
            var response = await _statistics.TotalPurchasedBook(month);
            return Ok(response);
        }
    }
}
