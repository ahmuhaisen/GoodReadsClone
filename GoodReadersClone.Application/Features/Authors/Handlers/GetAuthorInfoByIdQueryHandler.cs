using GoodReadsClone.Application.DTOs.Author;
using GoodReadsClone.Application.Features.Authors.Queries;

namespace GoodReadsClone.Application.Features.Authors.Handlers;
public class GetAuthorInfoByIdQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetAuthorInfoByIdQuery, ApiResponse>
{
    public async Task<ApiResponse> Handle(GetAuthorInfoByIdQuery request, CancellationToken cancellationToken)
    {
        var author = await _unitOfWork.AuthorRepository.GetAsync(request.AuthorId);

        if (author is null)
            return new ApiResponse { Message = "Author not found" };

        return new ApiResponse
        {
            Success = true,
            Data = new AuthorResponse
            {
                Id = author.Id,
                FullName = $"{author.FirstName} {author.LastName}",
                UserName = author.UserName,
                NumberOfBooks = author.Books.Count(),
            }
        };
    }
}
