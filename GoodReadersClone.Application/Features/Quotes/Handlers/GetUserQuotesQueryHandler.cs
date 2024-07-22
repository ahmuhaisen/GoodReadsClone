using GoodReadsClone.Application.DTOs;
using GoodReadsClone.Application.DTOs.Quote;
using GoodReadsClone.Application.Features.Quotes.Queries;
using GoodReadsClone.Domain.Entities;
using GoodReadsClone.Infrastructure.DataAccess.Abstractions;

namespace GoodReadsClone.Application.Features.Quotes.Handlers;

public class GetUserQuotesQueryHandler(
    IUnitOfWork _unitOfWork,
    UserManager<ApplicationUser> _userManager,
    IMapper _mapper)
    : IRequestHandler<GetUserQuotesQuery, ApiResponse>
{
    public async Task<ApiResponse> Handle(GetUserQuotesQuery request, CancellationToken cancellationToken)
    {
        if (request.Id.IsNullOrEmpty() || !await _userManager.Users.AnyAsync(x => x.Id == request.Id))
            return new ApiResponse { Message = "User Not Found" };

        var quotes = await _unitOfWork.QuoteRepository.GetAllAsync(q => q.UserId == request.Id);

        var result = _mapper.Map<IEnumerable<QuoteDto>>(quotes);

        return new ApiResponse
        {
            Success = true,
            Data = result
        };
    }
}
