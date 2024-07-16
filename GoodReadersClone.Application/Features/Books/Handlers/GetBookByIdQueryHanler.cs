using GoodReadersClone.Application.Features.Books.Queries;
using GoodReadersClone.Infrastructure.DataAccess.Abstractions;

namespace GoodReadersClone.Application.Features.Books.Handlers;

public class GetBookByIdQueryHanler(
    IUnitOfWork _unitOfWork
    )
    : IRequestHandler<GetBookByIdQuery, ApiResponse>
{
    public async Task<ApiResponse> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.BookRepository.GetByIdAsync(request.BookId);

        if (result == null)
            return new ApiResponse { Message = "Book not found" };

        return new ApiResponse
        {
            Success = true,
            Data = result
        };
    }
}