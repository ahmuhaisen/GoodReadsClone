using GoodReadersClone.Application.DTOs.Review;
using GoodReadersClone.Application.Features.Reviews.Queries;
using GoodReadersClone.Infrastructure.DataAccess.Abstractions;

namespace GoodReadersClone.Application.Features.Reviews.Handlers;

public class GetReaderBookReviewQueryHandler(
    IUnitOfWork _unitOfWork, UserManager<ApplicationUser> _userManager)
    : IRequestHandler<GetReaderBookReviewQuery, ApiResponse>
{
    public async Task<ApiResponse> Handle(GetReaderBookReviewQuery request, CancellationToken cancellationToken)
    {
        if (await _userManager.FindByIdAsync(request.ReaderId) is null)
            return new ApiResponse { Message = $"Reader with Id `{request.ReaderId}` Not Found" };

        if (!await _unitOfWork.BookRepository.IsExist(b => b.Id == request.BookId))
            return new ApiResponse { Message = $"Book with Id `{request.BookId}` Not Found" };

        var review = await _unitOfWork.ReviewRepository.GetAsync(r => r.ReaderId == request.ReaderId && r.BookId == request.BookId);

        if (review is null)
            return new ApiResponse { Message = $"Review Not Found" };

        var result = new ReviewResponse
        {
            Rating = review.Rating,
            CreatedAt = review.CreatedAt,
            Text = review.Text
        };

        return new ApiResponse
        {
            Success = true,
            Data = result
        };
    }
}


public class GetBookRatingSummaryQueryHandler(IUnitOfWork _unitOfWork)
    : IRequestHandler<GetBookRatingSummaryQuery, ApiResponse>
{
    public async Task<ApiResponse> Handle(GetBookRatingSummaryQuery request, CancellationToken cancellationToken)
    {
        if (!await _unitOfWork.BookRepository.IsExist(b => b.Id == request.BookId))
            return new ApiResponse { Message = $"Book with Id `{request.BookId}` Not Found" };

        var summary = await _unitOfWork.ReviewRepository.GetBookRatingSummaryAsync(request.BookId);

        if (summary is null)
            return new ApiResponse { Message = "Error Occured" };


        return new ApiResponse
        {
            Success = true,
            Data = summary
        };
    }
}
