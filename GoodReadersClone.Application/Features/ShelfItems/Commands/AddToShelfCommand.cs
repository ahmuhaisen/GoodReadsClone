using GoodReadersClone.Application.DTOs.ShelfItem;

namespace GoodReadersClone.Application.Features.ShelfItems.Commands;


public record AddToShelfCommand(ShelfRequest Request) : IRequest<ApiResponse>;
public record ChangeShelfCommand(ShelfRequest Request) : IRequest<ApiResponse>;
public record DeleteShelfItemCommand(string ReaderId, int BookId) : IRequest<ApiResponse>;
