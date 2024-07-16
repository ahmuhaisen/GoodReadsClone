namespace GoodReadersClone.Application.Features.Books.Queries;
public record GetBookByIdQuery(int BookId) : IRequest<ApiResponse>;
