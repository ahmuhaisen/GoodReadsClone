using GoodReadersClone.Application.DTOs.User;
using GoodReadersClone.Application.Features.Authors.Queries;
using GoodReadersClone.Infrastructure.DataAccess.Abstractions;

namespace GoodReadersClone.Application.Features.Authors.Handlers;
public class GetAllAuthorsQueryHandler(
    IUnitOfWork _unitOfWork,
    IMapper _mapper)
    : IRequestHandler<GetAllAuthorsQuery, ApiResponse>
{
    public async Task<ApiResponse> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
    {
        var allAuthors = await _unitOfWork.AuthorRepository.GetAllAsync();

        var result = _mapper.Map<IEnumerable<UserInfoModel>>(allAuthors);

        return new ApiResponse
        {
            Success = true,
            Data = result
        };
    }
}