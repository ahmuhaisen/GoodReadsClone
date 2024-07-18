using GoodReadersClone.Application.DTOs.ShelfItem;

namespace GoodReadersClone.Application.Features.ShelfItems.Commands;


public record AddToShelfCommand(AddToShelfRequest Request) : IRequest<ApiResponse>;
