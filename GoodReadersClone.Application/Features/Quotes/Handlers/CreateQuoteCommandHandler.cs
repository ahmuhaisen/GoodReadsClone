using GoodReadersClone.Application.Features.Quotes.Commands;
using GoodReadersClone.Infrastructure.DataAccess.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace GoodReadersClone.Application.Features.Quotes.Handlers;
public class CreateQuoteCommandHandler(
    IUnitOfWork _unitOfWork,
    UserManager<ApplicationUser> _userManager) 
    : IRequestHandler<CreateQuoteCommand, ApiResponse>
{
    public async Task<ApiResponse> Handle(CreateQuoteCommand request, CancellationToken cancellationToken)
    {
        if (request == null || request.Model == null)
            return new ApiResponse { Message = "Quote cann't be null" };

        if(!await _userManager.Users.AnyAsync(x => x.Id == request.Model.UserId))
            return new ApiResponse { Message = "User Not Found" };

        if(!await _unitOfWork.BookRepository.IsExist(x => x.Id == request.Model.BookId))
            return new ApiResponse { Message = "Book Not Found" };

        var quoteToAdd = new Quote
        {
            Body = request.Model.Body,
            UserId = request.Model.UserId,
            BookId = request.Model.BookId,
        };

        var result = _unitOfWork.QuoteRepository.Create(quoteToAdd);
        _unitOfWork.Save();

        if (result.Id == 0)
            return new ApiResponse { Message = "Failed to add the quote" };

        return new ApiResponse { Success = true, Data = result };
    }
}



