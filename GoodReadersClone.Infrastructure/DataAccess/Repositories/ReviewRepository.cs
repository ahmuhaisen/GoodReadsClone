using GoodReadersClone.Domain.Entities;
using GoodReadersClone.Domain.Models;
using GoodReadersClone.Infrastructure.DataAccess.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace GoodReadersClone.Infrastructure.DataAccess.Repositories;
public class ReviewRepository : Repository<Review>, IReviewRepository
{
    private readonly ApplicationDbContext _context;

    public ReviewRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<RatingSummaryModel> GetBookRatingSummaryAsync(int bookId)
    {
        var overallRating = await _context.Reviews
            .Where(r => r.BookId == bookId)
            .AverageAsync(r => r.Rating);

        var totalReviews = await _context.Reviews
            .CountAsync(r => r.BookId == bookId);

        return new RatingSummaryModel
        {
            OverallRating = overallRating,
            TotalReviews = totalReviews
        };
    }
}
