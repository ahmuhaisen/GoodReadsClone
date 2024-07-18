using GoodReadersClone.Application.Features.ShelfItems.Commands;
using GoodReadersClone.Domain.Enums;

namespace GoodReadersClone.Application.Features.ShelfItems.Handlers;

public class ChangeShelfCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<ChangeShelfCommand, ApiResponse>
{
    public async Task<ApiResponse> Handle(ChangeShelfCommand request, CancellationToken cancellationToken)
    {
        var shelfItem = await _unitOfWork.ShelfItemRepository.GetAsync(si => si.ReaderId == request.Request.ReaderId && si.BookId == request.Request.BookId);

        if (shelfItem is null)
            return new ApiResponse { Message = $"The Book with Id `{request.Request.BookId}` is not in your shelfs." };

        shelfItem!.Shelf = (Shelf)request.Request.Shelf;
        shelfItem.DateRead = (Shelf)request.Request.Shelf == Shelf.Read ? DateTime.UtcNow : null;

        _unitOfWork.ShelfItemRepository.Update(shelfItem);

        if (_unitOfWork.Save() == 0)
            return new ApiResponse { Message = "Error occured" };


        return new ApiResponse
        {
            Success = true,
            Data = shelfItem.Id,
        };
    }
}



public class DeleteShelfItemCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<DeleteShelfItemCommand, ApiResponse>
{
    public async Task<ApiResponse> Handle(DeleteShelfItemCommand request, CancellationToken cancellationToken)
    {
        var shelfItem = await _unitOfWork.ShelfItemRepository.GetAsync(si => si.ReaderId == request.ReaderId && si.BookId == request.BookId);

        if (shelfItem is null)
            return new ApiResponse { Message = $"The Book with Id `{request.BookId}` is not in your shelfs." };

        _unitOfWork.ShelfItemRepository.Delete(shelfItem);

        if (_unitOfWork.Save() == 0)
            return new ApiResponse { Message = "Error occured" };


        return new ApiResponse
        {
            Success = true,
        };
    }
}