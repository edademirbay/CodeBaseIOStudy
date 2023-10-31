using CodeBaseIOStudy.Dto;
using CodeBaseIOStudy.Entities;
using CodeBaseIOStudy.Filter;
using CodeBaseIOStudy.Wrappers;

namespace CodeBaseIOStudy.Interfaces
{
    public interface IOrder
    {
        Task<Response<Order>> GetById(long id);

        Task<Response<List<Order>>> GetByDate(DateTime endDate);
        Task<Response<Order>> PostOrder(NewOrderDto order);
    }
}
