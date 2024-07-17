using GoodReadersClone.Domain.Entities;
using GoodReadersClone.Domain.Models;

namespace GoodReadersClone.Infrastructure.DataAccess.Abstractions;
public interface IReviewRepository : IRepository<Review>
{
    Task<RatingSummaryModel> GetBookRatingSummaryAsync(int bookId);
}
