using CodeBaseIOStudy.Data;
using CodeBaseIOStudy.Dto;
using CodeBaseIOStudy.Entities;
using CodeBaseIOStudy.Filter;
using CodeBaseIOStudy.Interfaces;
using CodeBaseIOStudy.Wrappers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CodeBaseIOStudy.Services
{
    public class OrderService : IOrder
    {
        private readonly BookContext _bookContext;
        public OrderService(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public async Task<Response<List<Order>>> GetByDate(DateTime endDate)
        {
            var rangeDateOrders = await _bookContext.Orders.Where(x => x.Date <= endDate).ToListAsync();
            if(rangeDateOrders.Any())
            {
                return new Response<List<Order>>(rangeDateOrders);
            }
            return new Response<List<Order>>();
        }

        public async Task<Response<Order>> GetById(long id)
        {
            var orderDetail = await _bookContext.Orders.FindAsync(id);
            if(orderDetail is null)
            {
                return new Response<Order>();
            }
            return new Response<Order>(orderDetail);
        }

        public async Task<Response<Order>> PostOrder(NewOrderDto order)
        {
            var bookId = await _bookContext.Books.Where(x=>x.Id==order.BookId).FirstOrDefaultAsync();

            if(bookId is null)
            {
                return new Response<Order>();
            }
            //stock update with by book
            var stockEntities = await _bookContext.Stocks.Where(x => x.BookId == bookId.Id).FirstOrDefaultAsync();

            if (stockEntities is null || stockEntities.Amount == 0)
            {
                return new Response<Order>();
            }
            if (stockEntities is null  || (order.Count > stockEntities.Amount))
            {
                return new Response<Order>();
                
            }
            stockEntities.Amount = stockEntities.Amount - order.Count;
            
           
             _bookContext.Stocks.Update(stockEntities);

            // add order
            var addOrder = new Order
            {
                CustomerId = 1, // login user session
                AddressId = 1, // customer address
                BookId = order.BookId,
                Date = DateTime.Now,
                Count=order.Count

            };
            _bookContext.Orders.Add(addOrder);

            await _bookContext.SaveChangesAsync();

            return new Response<Order>(addOrder);
        }
    }
}
