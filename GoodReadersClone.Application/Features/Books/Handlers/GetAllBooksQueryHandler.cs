using GoodReadsClone.Application.DTOs;
using GoodReadsClone.Application.DTOs.Books;
using GoodReadsClone.Application.Features.Books.Queries;
using GoodReadsClone.Domain.Models;
using GoodReadsClone.Infrastructure.DataAccess.Abstractions;

namespace GoodReadsClone.Application.Features.Books.Handlers;
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
