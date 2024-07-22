using GoodReadsClone.Application.DTOs.Review;

namespace GoodReadsClone.Application.Features.Reviews.Commands;
public record CreateReviewCommand(CreateReviewRequest Review) : IRequest<ApiResponse>;
public record EditReviewCommand(string ReaderId, int BookId, EditReviewRequest Review) : IRequest<ApiResponse>;
public record DeleteReviewCommand(string ReaderId, int BookId) : IRequest<ApiResponse>;

