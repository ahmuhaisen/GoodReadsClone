using GoodReadsClone.Application.DTOs;
using GoodReadsClone.Application.Features.Reviews.Commands;
using GoodReadsClone.Infrastructure.DataAccess.Abstractions;

namespace GoodReadsClone.Application.Features.Reviews.Handlers;

public class DeleteReviewCommandHandler(IUnitOfWork _unitOfWork)
    : IRequestHandler<DeleteReviewCommand, ApiResponse>
{
    public async Task<ApiResponse> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
    {
        var reviewToDelete = await _unitOfWork.ReviewRepository.GetAsync(r => r.BookId == request.BookId && r.ReaderId == request.ReaderId);

        if (reviewToDelete is null)
            return new ApiResponse { Message = "Review Not Found" };

        _unitOfWork.ReviewRepository.Delete(reviewToDelete);
        var result = _unitOfWork.Save();

        if (result == 0)
            return new ApiResponse { Message = "Failed to delete the review" };

        return new ApiResponse
        {
            Success = true,
            Data = new { result }
        };
    }
}