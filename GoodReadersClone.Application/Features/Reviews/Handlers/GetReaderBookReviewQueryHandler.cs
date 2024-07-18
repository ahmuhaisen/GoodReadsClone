using GoodReadersClone.Application.DTOs.Review;
using GoodReadersClone.Application.Features.Reviews.Queries;

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