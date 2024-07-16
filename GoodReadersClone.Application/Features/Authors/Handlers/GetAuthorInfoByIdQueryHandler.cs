using GoodReadersClone.Application.DTOs.Author;
using GoodReadersClone.Application.Features.Authors.Queries;
using GoodReadersClone.Infrastructure.DataAccess.Abstractions;

namespace GoodReadersClone.Application.Features.Authors.Handlers;
public class GetAuthorInfoByIdQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetAuthorInfoByIdQuery, ApiResponse>
{
    public async Task<ApiResponse> Handle(GetAuthorInfoByIdQuery request, CancellationToken cancellationToken)
    {
        var author = await _unitOfWork.AuthorRepository.GetAsync(request.InfoRequest.AuthorId);

        if (author is null)
            return new ApiResponse(false, "Author not found", null!);

        return new ApiResponse(true, null, new AuthorInfoModel
        {
            Id = author.Id,
            FullName = $"{author.FirstName} {author.LastName}",
            UserName = author.UserName,
            NumberOfBooks = author.Books.Count(),
            NoOfFollowers = "Comming Soon"
        });
    }
}
