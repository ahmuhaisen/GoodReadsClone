using GoodReadsClone.Application.DTOs;
using GoodReadsClone.Application.DTOs.ShelfItem;

namespace GoodReadsClone.Application.Features.ShelfItems.Commands;


public record AddToShelfCommand(ShelfRequest Request) : IRequest<ApiResponse>;
public record ChangeShelfCommand(ShelfRequest Request) : IRequest<ApiResponse>;
public record DeleteShelfItemCommand(string ReaderId, int BookId) : IRequest<ApiResponse>;
