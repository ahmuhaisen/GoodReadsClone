using GoodReadersClone.Application.Features.ShelfItems.Commands;
using GoodReadersClone.Domain.Enums;

namespace GoodReadersClone.Application.Features.ShelfItems.Handlers;

public class AddToShelfCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<AddToShelfCommand, ApiResponse>
{
    public async Task<ApiResponse> Handle(AddToShelfCommand request, CancellationToken cancellationToken)
    {
        if (!await _unitOfWork.BookRepository.IsExist(b => b.Id == request.Request.BookId))
            return new ApiResponse { Message = $"Book with Id `{request.Request.BookId}` Not Found" };

        if (await _unitOfWork.ShelfItemRepository.IsExist(si => si.ReaderId == request.Request.ReaderId && si.BookId == request.Request.BookId))
            return new ApiResponse { Message = $"The Book with Id `{request.Request.BookId}` already in your shelfs, try change the shelf insted." };

        var shelfItem = new ShelfItem
        {
            BookId = request.Request.BookId,
            ReaderId = request.Request.ReaderId,
            Shelf = (Shelf)request.Request.Shelf,
            DateRead = (Shelf)request.Request.Shelf == Shelf.Read ? DateTime.UtcNow : null,
        };

        _unitOfWork.ShelfItemRepository.Create(shelfItem);

        if (_unitOfWork.Save() == 0)
            return new ApiResponse { Message = "Error occured" };


        return new ApiResponse
        {
            Success = true,
            Data = shelfItem.Id,
        };
    }
}
