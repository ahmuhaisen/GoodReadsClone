namespace GoodReadersClone.Application.Features.ShelfItems.Queries;
public record GetAllShelfItemsQuery(string ReaderId) : IRequest<ApiResponse>;