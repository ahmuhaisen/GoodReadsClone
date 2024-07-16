using GoodReadersClone.Application.Features.Quotes.Queries;
using GoodReadersClone.Infrastructure.DataAccess.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace GoodReadersClone.Application.Features.Quotes.Handlers;

public class GetUserQuotesQueryHandler(
    IUnitOfWork _unitOfWork, 
    UserManager<ApplicationUser> _userManager)
    : IRequestHandler<GetUserQuotesQuery, ApiResponse>
{
    public async Task<ApiResponse> Handle(GetUserQuotesQuery request, CancellationToken cancellationToken)
    {
        if (request.Id.IsNullOrEmpty() || !await _userManager.Users.AnyAsync(x => x.Id == request.Id))
            return new ApiResponse { Message = "User Not Found" };

        var quotes = await _unitOfWork.QuoteRepository.GetAllAsync(q => q.UserId == request.Id);

        return new ApiResponse { Success = true, Data = quotes };
    }
}

public class GetBookQuotesQueryHandler(
    IUnitOfWork _unitOfWork)
    : IRequestHandler<GetBookQuotesQuery, ApiResponse>
{
    public async Task<ApiResponse> Handle(GetBookQuotesQuery request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0 || !await _unitOfWork.BookRepository.IsExist(x => x.Id == request.Id))
            return new ApiResponse { Message = "Book Not Found" };

        var quotes = await _unitOfWork.QuoteRepository.GetAllAsync(q => q.BookId == request.Id);

        return new ApiResponse { Success = true, Data = quotes };
    }
}