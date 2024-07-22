using GoodReadsClone.Application.DTOs;

namespace GoodReadsClone.Application.Features.ShelfItems.Queries;
public record GetAllShelfItemsQuery(string ReaderId) : IRequest<ApiResponse>;