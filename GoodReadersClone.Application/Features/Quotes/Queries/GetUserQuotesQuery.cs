namespace GoodReadersClone.Application.Features.Quotes.Queries;
public record GetUserQuotesQuery(string Id) : IRequest<ApiResponse>;
public record GetBookQuotesQuery(int Id) : IRequest<ApiResponse>;

