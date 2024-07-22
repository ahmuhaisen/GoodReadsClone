using GoodReadersClone.Application.DTOs.Review;
using GoodReadsClone.Application.DTOs;
using GoodReadsClone.Application.Features.Reviews.Queries;
using GoodReadsClone.Domain.Entities;
using GoodReadsClone.Infrastructure.DataAccess.Abstractions;

namespace GoodReadsClone.Application.Features.Reviews.Handlers;

public class GetReaderReviewsQueryHandler(
    IUnitOfWork _unitOfWork, UserManager<ApplicationUser> _userManager)
    : IRequestHandler<GetReaderReviewsQuery, ApiResponse>
{
    public async Task<ApiResponse> Handle(GetReaderReviewsQuery request, CancellationToken cancellationToken)
    {
        if (await _userManager.FindByIdAsync(request.ReaderId) is null)
            return new ApiResponse { Message = $"Reader with Id `{request.ReaderId}` Not Found" };

        var reviews = await _unitOfWork.ReviewRepository.GetAllAsync(r => r.ReaderId == request.ReaderId, new[] { "Book" });

        var result = reviews.Select(r => new ReviewResponse
        {
            BookName = r.Book.Title,
            Rating = r.Rating,
            CreatedAt = r.CreatedAt,
            Text = r.Text
        });

        return new ApiResponse
        {
            Success = true,
            Data = result
        };
    }
}