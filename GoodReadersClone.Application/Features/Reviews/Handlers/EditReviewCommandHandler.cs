using GoodReadersClone.Application.Features.Reviews.Commands;

namespace GoodReadersClone.Application.Features.Reviews.Handlers;

public class EditReviewCommandHandler(IUnitOfWork _unitOfWork)
    : IRequestHandler<EditReviewCommand, ApiResponse>
{
    public async Task<ApiResponse> Handle(EditReviewCommand request, CancellationToken cancellationToken)
    {
        var reviewToUpdate = await _unitOfWork.ReviewRepository.GetAsync(r => r.BookId == request.BookId && r.ReaderId == request.ReaderId);

        if (reviewToUpdate is null)
            return new ApiResponse { Message = "Review Not Found" };

        reviewToUpdate.Rating = request.Review.Rating;

        if(!request.Review.Text.IsNullOrEmpty())
            reviewToUpdate.Text = request.Review.Text;

        reviewToUpdate.CreatedAt = DateTime.Now;

        _unitOfWork.ReviewRepository.Update(reviewToUpdate);
        var result = _unitOfWork.Save();

        if (result == 0)
            return new ApiResponse { Message = "Failed to update the review" };

        return new ApiResponse
        {
            Success = true,
            Data = new { result }
        };
    }
}