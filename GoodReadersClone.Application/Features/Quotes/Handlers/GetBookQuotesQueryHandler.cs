using GoodReadersClone.Application.Features.Quotes.Queries;
using GoodReadersClone.Infrastructure.DataAccess.Abstractions;

namespace GoodReadersClone.Application.Features.Quotes.Handlers;

public class GetBookQuotesQueryHandler(
    IUnitOfWork _unitOfWork)
    : IRequestHandler<GetBookQuotesQuery, ApiResponse>
{
    public async Task<ApiResponse> Handle(GetBookQuotesQuery request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0 || !await _unitOfWork.BookRepository.IsExist(x => x.Id == request.Id))
            return new ApiResponse { Message = "Book Not Found" };

        var quotes = await _unitOfWork.QuoteRepository.GetAllAsync(q => q.BookId == request.Id);

        return new ApiResponse 
        {
            Success = true,
            Data = quotes
        };
    }
}