using CodeBaseIOStudy.Data;
using CodeBaseIOStudy.Entities;
using CodeBaseIOStudy.Filter;
using CodeBaseIOStudy.Interfaces;
using CodeBaseIOStudy.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeBaseIOStudy.Services
{
    public class CustomerService : ICustomer
    {
        private readonly BookContext _bookContext;
        public CustomerService(BookContext bookContext)
        {
            _bookContext = bookContext;
        }
        public async Task<Response<List<Customer>>> GetAll(PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = await _bookContext.Customers
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToListAsync();         
            return new PagedResponse<List<Customer>>(pagedData, validFilter.PageNumber, validFilter.PageSize);
        }    

        public async Task<Response<Customer>> PostCustomer(Customer customer)
        {
            var customerDetail=await _bookContext.Customers.Where(x=>x.Email== customer.Email).ToListAsync();
            if(customerDetail.Count >= 1)
            {
                return new Response<Customer>();
            }
            _bookContext.Customers.Add(customer);
            await _bookContext.SaveChangesAsync();
            return new Response<Customer>(customer);
        }

        public async Task<Response<Customer>> GetById(long id)
        {
            var customer = await _bookContext.Customers.FindAsync(id);
            if(customer is null) {
                return new Response<Customer>();                
            }

            return new Response<Customer>(customer);

        }
    }
}
