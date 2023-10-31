using CodeBaseIOStudy.Data;
using CodeBaseIOStudy.Entities;
using CodeBaseIOStudy.Filter;
using CodeBaseIOStudy.Interfaces;
using CodeBaseIOStudy.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeBaseIOStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _customer;
        public CustomerController(ICustomer customer)
        {
            _customer = customer;
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            var response=await _customer.GetAll(filter);
            return Ok(response);
        }
       

        [HttpGet]
        [Route("get-customer-by-id/{id:long}")]
        [Authorize]
        public async Task<IActionResult> GetById(long id)
        {
           var response= await _customer.GetById(id);
            if(response.Data is null)
            {
                return NoContent();
            }
            return Ok(response);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostCustomer(Customer customer)
        {
            var response=await _customer.PostCustomer(customer);

            if(response.Data is null) {
                return NoContent();
            }

            return Created($"get-customer-by-id/{response.Data.Id}", customer);
        }
    }
}


