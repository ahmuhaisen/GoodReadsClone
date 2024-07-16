using GoodReadersClone.Application.Features.Books.Queries;
using GoodReadersClone.Domain.Models;
using GoodReadersClone.Infrastructure.DataAccess.Abstractions;

namespace GoodReadersClone.Application.Features.Books.Handlers;
public class GetAllBooksQueryHandler(
    IUnitOfWork _unitOfWork,
    IMapper _mapper
    )
    : IRequestHandler<GetAllBooksQuery, PaginatedList<Book>>
{
    public async Task<PaginatedList<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _unitOfWork.BookRepository.GetAllAsync(request.Request.PageIndex, request.Request.PageSize);

        return books;
    }
}
