using GoodReadersClone.Application.Features.Reviews.Queries;

namespace GoodReadersClone.Application.Features.Reviews.Handlers;

public class GetBookRatingSummaryQueryHandler(IUnitOfWork _unitOfWork)
    : IRequestHandler<GetBookRatingSummaryQuery, ApiResponse>
{
    public async Task<ApiResponse> Handle(GetBookRatingSummaryQuery request, CancellationToken cancellationToken)
    {
        if (!await _unitOfWork.BookRepository.IsExist(b => b.Id == request.BookId))
            return new ApiResponse { Message = $"Book with Id `{request.BookId}` Not Found" };

        var summary = await _unitOfWork.ReviewRepository.GetBookRatingSummaryAsync(request.BookId);

        if (summary is null)
            return new ApiResponse { Message = "Error Occured" };


        return new ApiResponse
        {
            Success = true,
            Data = summary
        };
    }
}