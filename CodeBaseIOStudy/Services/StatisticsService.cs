using CodeBaseIOStudy.Data;
using CodeBaseIOStudy.Interfaces;
using CodeBaseIOStudy.Wrappers;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CodeBaseIOStudy.Services
{
    public class StatisticsService : IStatistics
    {
        private readonly BookContext _bookContext;
        public StatisticsService(BookContext bookContext)
        {
            _bookContext = bookContext;
        }
        public async Task<Response<int>> TotalOrder(int month)
        {
            var totalOrder=(await _bookContext.Orders.Where(x => x.Date.Month == month).ToListAsync()).Count();
            return new Response<int>(totalOrder);
        }

        public async Task<Response<decimal>> TotalPurchased(int month)
        {
            var allOrders= await _bookContext.Orders.Where(x => x.Date.Month == month).ToListAsync();
            var allBookId=allOrders.Select(x => x.BookId);
          
            var allPurchasedPrice = (await _bookContext.Books.Where(x => allBookId.Contains(x.Id)).Select(x => x.Price).SumAsync());
            
           return new Response<decimal>(allPurchasedPrice);
           
        }
        

        public async Task<Response<int>> TotalPurchasedBook(int month)
        {
            var allOrders = await _bookContext.Orders.Where(x => x.Date.Month == month).ToListAsync();
            var allBookId = allOrders.Select(x => x.BookId);
            var allStock = await _bookContext.Stocks.SumAsync(x=>x.Amount);
            var stokcsByBookId= await _bookContext.Stocks.Where(x=> allBookId.Contains(x.Id)).Select(y=>y.Amount).SumAsync();

            var purchasedBook = allStock - stokcsByBookId;
            return new Response<int>(purchasedBook);

        }
    }
}
