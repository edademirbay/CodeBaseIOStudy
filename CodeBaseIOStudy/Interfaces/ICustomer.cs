using CodeBaseIOStudy.Entities;
using CodeBaseIOStudy.Filter;
using CodeBaseIOStudy.Wrappers;

namespace CodeBaseIOStudy.Interfaces
{
    public interface ICustomer
    {
        Task<Response<List<Customer>>> GetAll(PaginationFilter filter);

        Task<Response<Customer>> GetById(long id);
        Task<Response<Customer>> PostCustomer(Customer customer);
    }
}
