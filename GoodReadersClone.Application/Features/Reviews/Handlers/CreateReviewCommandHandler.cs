using GoodReadsClone.Application.DTOs;
using GoodReadsClone.Application.Features.Reviews.Commands;
using GoodReadsClone.Domain.Entities;
using GoodReadsClone.Infrastructure.DataAccess.Abstractions;

namespace GoodReadsClone.Application.Features.Reviews.Handlers;

public class CreateReviewCommandHandler(
    IUnitOfWork _unitOfWork,
    IMapper _mapper)
    : IRequestHandler<CreateReviewCommand, ApiResponse>
{
    public async Task<ApiResponse> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        if (await _unitOfWork.ReviewRepository.IsExist(r => r.BookId == request.Review.BookId && r.ReaderId == request.Review.ReaderId))
            return new ApiResponse { Message = "Review already exist for this book" };

        if (!await _unitOfWork.BookRepository.IsExist(b => b.Id == request.Review.BookId))
            return new ApiResponse { Message = $"Book with Id `{request.Review.BookId}` Not Found" };

        var reviewToCreate = _mapper.Map<Review>(request.Review);
        reviewToCreate.CreatedAt = DateTime.Now;

        _unitOfWork.ReviewRepository.Create(reviewToCreate);
        var result = _unitOfWork.Save();

        if (result == 0)
            return new ApiResponse { Message = "Failed to create the review" };

        return new ApiResponse
        {
            Success = true,
            Data = new { result }
        };
    }
}