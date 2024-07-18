using GoodReadersClone.Application.DTOs.Books;
using GoodReadersClone.Application.Features.Books.Commands;
using GoodReadersClone.Application.Features.Books.Queries;

namespace GoodReadersClone.Application.Features.Books.Handlers;

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

        var result = BookModel.ConvertBookToBookModel(book);


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


public class CreateBookCommandHandler(
    IUnitOfWork _unitOfWork,
    IMapper _mapper
    )
    : IRequestHandler<CreateBookCommand, ApiResponse>
{
    public async Task<ApiResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        if (!_unitOfWork.AuthorRepository.IsExist(x => x.Id == request.Request.AuthorId))
            return new ApiResponse { Message = "Author Not Found" };

        if (await _unitOfWork.BookRepository.IsExist(x => x.Title == request.Request.Title))
            return new ApiResponse { Message = "There exist a book with same title" };

        if (request.Request.FirstPublished > DateTime.Now)
            return new ApiResponse { Message = "Invalid FirstPublished Date" };

        var bookToAdd = new Book();

        bookToAdd = _mapper.Map<Book>(request.Request);

        if (request.Request.Cover is not null)
        {
            //Save Image
        }
        bookToAdd.CoverURL = $"{FileManager.BooksCoversPath}\\{Guid.NewGuid().ToString()}.jpg";

        if (!string.IsNullOrEmpty(request.Request.Genres))
        {
            var genresToAttach = request.Request.Genres.Split(',').Select(x => x.Trim());
            foreach (var genreName in genresToAttach)
            {
                var genre = await _unitOfWork.GenreRepository.GetAsync(x => x.Name == genreName);
                if (genre is not null)
                    bookToAdd.Genres.Add(genre);
            }
        }

        _unitOfWork.BookRepository.Create(bookToAdd);
        var result = _unitOfWork.Save();

        if (result == 0)
            return new ApiResponse { Message = "Failed to create the book" };

        return new ApiResponse
        {
            Success = true,
            Data = bookToAdd.Id
        };
    }
}
