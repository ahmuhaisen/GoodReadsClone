using GoodReadsClone.Application.DTOs;
using GoodReadsClone.Application.DTOs.Author;
using GoodReadsClone.Application.Features.Authors.Queries;
using GoodReadsClone.Infrastructure.DataAccess.Abstractions;

namespace GoodReadsClone.Application.Features.Authors.Handlers;
public class GetAllAuthorsQueryHandler(
    IUnitOfWork _unitOfWork,
    IMapper _mapper)
    : IRequestHandler<GetAllAuthorsQuery, ApiResponse>
{
    public async Task<ApiResponse> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
    {
        var allAuthors = await _unitOfWork.AuthorRepository.GetAllAsync();

        var result = _mapper.Map<IEnumerable<AuthorResponse>>(allAuthors);

        return new ApiResponse
        {
            Success = true,
            Data = result
        };
    }
}