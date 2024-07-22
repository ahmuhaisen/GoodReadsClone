using GoodReadsClone.Application.DTOs;
using GoodReadsClone.Application.Features.ShelfItems.Queries;
using GoodReadsClone.Infrastructure.DataAccess.Abstractions;

namespace GoodReadsClone.Application.Features.ShelfItems.Handlers;
public class GetAllShelfItemsQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetAllShelfItemsQuery, ApiResponse>
{
    public async Task<ApiResponse> Handle(GetAllShelfItemsQuery request, CancellationToken cancellationToken)
    {
        var shelfItems = await _unitOfWork.ShelfItemRepository.GetShelfItemsAsync(request.ReaderId);

        if (shelfItems.Count() == 0)
            return new ApiResponse { Message = "No matching items!" };

        return new ApiResponse
        {
            Success = true,
            Data = shelfItems,
        };
    }
}
