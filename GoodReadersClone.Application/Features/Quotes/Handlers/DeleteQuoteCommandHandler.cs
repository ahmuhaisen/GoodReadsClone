using GoodReadersClone.Application.Features.Quotes.Commands;
using Microsoft.AspNetCore.Http;

namespace GoodReadersClone.Application.Features.Quotes.Handlers;

public class DeleteQuoteCommandHandler(
    IUnitOfWork _unitOfWork,
    IHttpContextAccessor _httpContextAccessor)
    : IRequestHandler<DeleteQuoteCommand, ApiResponse>
{
    public async Task<ApiResponse> Handle(DeleteQuoteCommand request, CancellationToken cancellationToken)
    {
        if (request == null || request.Id <= 0 || !await _unitOfWork.QuoteRepository.IsExist(x => x.Id == request.Id))
            return new ApiResponse { Message = "Invalid Quote Id" };
              

        var quoteToDelete = await _unitOfWork.QuoteRepository.GetByIdAsync(request.Id);

        var currentUserId = _httpContextAccessor.HttpContext.User.FindFirstValue("uid");

        if(currentUserId != quoteToDelete.UserId)
            return new ApiResponse { Message = "You cann't delete this quote" };


        _unitOfWork.QuoteRepository.Delete(quoteToDelete);
       
        if (_unitOfWork.Save() == 0)
            return new ApiResponse { Message = "Failed to delete the quote" };

        return new ApiResponse
        {
            Success = true,
            Message = "Deleted Successfully",
            Data = null
        };
    }
}
