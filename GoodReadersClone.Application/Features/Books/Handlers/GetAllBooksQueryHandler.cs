using GoodReadersClone.Application.DTOs.Books;
using GoodReadersClone.Application.Features.Books.Queries;
using GoodReadersClone.Domain.Models;
using GoodReadersClone.Infrastructure.DataAccess.Abstractions;

namespace GoodReadersClone.Application.Features.Books.Handlers;
public class GetAllBooksQueryHandler(
    IUnitOfWork _unitOfWork,
    IMapper _mapper
    )
    : IRequestHandler<GetAllBooksQuery, ApiResponse>
{
    public async Task<ApiResponse> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _unitOfWork.BookRepository.GetAllAsync(request.PageIndex, request.PageSize);

        var result = new PaginatedList<BookModel>(
            items: books.Items.Select(x => new BookModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Author = $"{x.Author.FirstName} {x.Author.LastName}",
                CoverURL = x.CoverURL,
                FirstPublished = x.FirstPublished,
                Genres = string.Join(',', x.Genres.Select(y => y.Name))
            }).ToList(), books.PageIndex, books.TotalPages);

        return new ApiResponse
        {
            Success = true,
            Data = result
        };
    }
}
