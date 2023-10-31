using CodeBaseIOStudy.Data;
using CodeBaseIOStudy.Dto;
using CodeBaseIOStudy.Entities;
using CodeBaseIOStudy.Interfaces;
using CodeBaseIOStudy.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeBaseIOStudy.Controllers
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
        [HttpGet("{id:long}"), Authorize]
        public async Task<IActionResult> GetOrderById(long id)
        {
            var response = await _order.GetById(id);
            if (response.Data is null)
            {
                return NoContent();
            }
            return Ok(response);
        }

        [HttpGet("{endDate:DateTime}"), Authorize]
        public async Task<IActionResult> GetOrdersByDate(DateTime endDate)
        {
            var response = await _order.GetByDate(endDate);
            if(response.Data is null)
            {
                return NoContent();
            }
            return Ok(response);

        }

        [HttpPost,Authorize]
        public async Task<ActionResult<Order>> PostOrder([FromBody] NewOrderDto order)
        {
            var response = await _order.PostOrder(order);

            if(response.Data is null)
            {
                return NoContent();
            }

            return CreatedAtAction(nameof(GetOrderById),
                    new { id = response.Data.Id }, response);
        }

    }
}
