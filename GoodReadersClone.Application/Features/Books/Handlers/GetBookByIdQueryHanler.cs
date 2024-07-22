using GoodReadsClone.Application.DTOs;
using GoodReadsClone.Application.DTOs.Books;
using GoodReadsClone.Application.Features.Books.Queries;
using GoodReadsClone.Infrastructure.DataAccess.Abstractions;

namespace GoodReadsClone.Application.Features.Books.Handlers;

public class GetBookByIdQueryHanler(
    IUnitOfWork _unitOfWork
    )
    : IRequestHandler<GetBookByIdQuery, ApiResponse>
{
    public async Task<ApiResponse> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await _unitOfWork.BookRepository.GetAsync(x => x.Id == request.BookId, new[] { "Genres", "Author" });

        if (book == null)
            return new ApiResponse { Message = "Book not found" };

        var result = BookResponse.ConvertBookToBookModel(book);


        return new ApiResponse
        {
            Success = true,
            Data = result
        };
    }
}


public class GetBookByISBNQueryHanler(
    IUnitOfWork _unitOfWork
    )
    : IRequestHandler<GetBookByISBNQuery, ApiResponse>
{
    public async Task<ApiResponse> Handle(GetBookByISBNQuery request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.BookRepository.GetAsync(x => x.ISBN.Equals(request.ISBN));

        if (result == null)
            return new ApiResponse { Message = "Book not found" };

        return new ApiResponse
        {
            Success = true,
            Data = result
        };
    }
}
