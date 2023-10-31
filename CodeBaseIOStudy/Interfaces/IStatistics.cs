using CodeBaseIOStudy.Wrappers;

namespace CodeBaseIOStudy.Interfaces
{
    public interface IStatistics
    {
        Task<Response<int>> TotalOrder(int month);

        Task<Response<decimal>> TotalPurchased(int month);

        Task<Response<int>> TotalPurchasedBook(int month);
    }
}
