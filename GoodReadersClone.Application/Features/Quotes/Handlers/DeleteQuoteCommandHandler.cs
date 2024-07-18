using GoodReadersClone.Application.Features.Quotes.Commands;

namespace GoodReadersClone.Application.Features.Quotes.Handlers;

public class DeleteQuoteCommandHandler(
    IUnitOfWork _unitOfWork)
    : IRequestHandler<DeleteQuoteCommand, ApiResponse>
{
    public async Task<ApiResponse> Handle(DeleteQuoteCommand request, CancellationToken cancellationToken)
    {
        if (request == null || request.Id <= 0 || !await _unitOfWork.QuoteRepository.IsExist(x => x.Id == request.Id))
            return new ApiResponse { Message = "Invalid Quote Id" };
              

        var quoteToDelete = await _unitOfWork.QuoteRepository.GetByIdAsync(request.Id);

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
