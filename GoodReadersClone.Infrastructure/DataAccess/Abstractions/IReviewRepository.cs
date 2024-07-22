using GoodReadsClone.Domain.Entities;
using GoodReadsClone.Domain.Models;

namespace GoodReadsClone.Infrastructure.DataAccess.Abstractions;
public interface IReviewRepository : IRepository<Review>
{
    Task<RatingSummaryModel> GetBookRatingSummaryAsync(int bookId);
}
