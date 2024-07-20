using GoodReadersClone.Application.DTOs.Books;
using GoodReadersClone.Application.Features.Books.Queries;
using GoodReadersClone.Domain.Models;

namespace GoodReadersClone.Application.Features.Books.Handlers;
public class GetAllBooksQueryHandler(IUnitOfWork _unitOfWork)
    : IRequestHandler<GetAllBooksQuery, ApiResponse>
{
    public async Task<ApiResponse> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _unitOfWork.BookRepository.GetAllAsync(request.PageIndex, request.PageSize);

        var result = new PaginatedList<BookResponse>(
            items: books.Items.Select(x => new BookResponse
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description ?? string.Empty,
                Author = $"{x.Author.FirstName} {x.Author.LastName}",
                CoverURL = x.CoverURL,
                FirstPublished = x.FirstPublished,
                ISBN = x.ISBN,
                Genres = string.Join(',', x.Genres.Select(y => y.Name))
            }).ToList(), books.PageIndex, books.TotalPages);

        return new ApiResponse
        {
            Success = true,
            Data = result
        };
    }
}
