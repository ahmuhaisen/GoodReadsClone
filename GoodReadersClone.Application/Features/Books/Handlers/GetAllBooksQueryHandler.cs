using GoodReadersClone.Application.DTOs.Books;
using GoodReadersClone.Application.Features.Books.Queries;
using GoodReadersClone.Domain.Models;

namespace GoodReadersClone.Application.Features.Books.Handlers;
public class GetAllBooksQueryHandler(IUnitOfWork _unitOfWork, IMapper _mapper)
    : IRequestHandler<GetAllBooksQuery, ApiResponse>
{
    public async Task<ApiResponse> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _unitOfWork.BookRepository.GetAllAsync(request.SearchTerm, request.PageIndex, request.PageSize);

        var result = _mapper.Map<PaginatedList<BookResponse>>(books);

        return new ApiResponse
        {
            Success = true,
            Data = result
        };
    }
}
