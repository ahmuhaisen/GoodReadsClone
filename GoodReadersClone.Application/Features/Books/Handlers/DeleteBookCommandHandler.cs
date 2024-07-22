using GoodReadsClone.Application.DTOs;
using GoodReadsClone.Application.Features.Books.Commands;
using GoodReadsClone.Infrastructure.DataAccess.Abstractions;

namespace GoodReadsClone.Application.Features.Books.Handlers;

public class DeleteBookCommandHandler(IUnitOfWork _unitOfWork)
    : IRequestHandler<DeleteBookCommand, ApiResponse>
{
    public async Task<ApiResponse> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var bookToDelete = await _unitOfWork.BookRepository.GetAsync(x => x.Id == request.BookId);

        if (bookToDelete is null)
            return new ApiResponse { Message = $"Book with Id `{request.BookId}` Not Found" };


        if (!string.IsNullOrEmpty(bookToDelete.CoverURL))
        {
            //Delete the Cover
        }

        _unitOfWork.BookRepository.Delete(bookToDelete);
        var result = _unitOfWork.Save();

        if (result == 0)
            return new ApiResponse { Message = "Failed to delete the book" };

        return new ApiResponse
        {
            Success = true,
            Message = "Deleted Successfully",
        };
    }
}