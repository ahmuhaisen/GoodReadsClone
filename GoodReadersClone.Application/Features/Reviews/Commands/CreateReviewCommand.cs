using GoodReadersClone.Application.DTOs.Review;

namespace GoodReadersClone.Application.Features.Reviews.Commands;
public record CreateReviewCommand(ReviewRequest Review) : IRequest<ApiResponse>;
public record EditReviewCommand(ReviewRequest Review) : IRequest<ApiResponse>;
public record DeleteReviewCommand(string ReaderId, int BookId) : IRequest<ApiResponse>;

