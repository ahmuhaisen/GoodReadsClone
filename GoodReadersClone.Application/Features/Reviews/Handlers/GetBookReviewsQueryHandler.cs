using GoodReadersClone.Application.DTOs.Review;
using GoodReadsClone.Application.DTOs;
using GoodReadsClone.Application.Features.Reviews.Queries;
using GoodReadsClone.Infrastructure.DataAccess.Abstractions;

namespace GoodReadsClone.Application.Features.Reviews.Handlers;

public class GetBookReviewsQueryHandler(
    IUnitOfWork _unitOfWork)
    : IRequestHandler<GetBookReviewsQuery, ApiResponse>
{
    public async Task<ApiResponse> Handle(GetBookReviewsQuery request, CancellationToken cancellationToken)
    {
        if (!await _unitOfWork.BookRepository.IsExist(b => b.Id == request.BookId))
            return new ApiResponse { Message = $"Book with Id `{request.BookId}` Not Found" };

        var reviews = await _unitOfWork.ReviewRepository.GetAllAsync(r => r.BookId == request.BookId, new[] { "Reader" });

        var result = reviews.Select(r => new ReviewResponse
        {
            ReaderName = $"{r.Reader.FirstName} {r.Reader.LastName}",
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