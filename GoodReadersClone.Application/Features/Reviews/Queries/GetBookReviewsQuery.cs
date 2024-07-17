namespace GoodReadersClone.Application.Features.Reviews.Queries;
public record GetBookReviewsQuery(int BookId) : IRequest<ApiResponse>;
public record GetReaderReviewsQuery(string ReaderId) : IRequest<ApiResponse>;
public record GetReaderBookReviewQuery(string ReaderId, int BookId) : IRequest<ApiResponse>;
public record GetBookRatingSummaryQuery(int BookId) : IRequest<ApiResponse>;