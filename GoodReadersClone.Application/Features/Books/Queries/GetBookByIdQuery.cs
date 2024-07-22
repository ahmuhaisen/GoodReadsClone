namespace GoodReadsClone.Application.Features.Books.Queries;
public record GetBookByIdQuery(int BookId) : IRequest<ApiResponse>;
public record GetBookByISBNQuery(string ISBN) : IRequest<ApiResponse>;
