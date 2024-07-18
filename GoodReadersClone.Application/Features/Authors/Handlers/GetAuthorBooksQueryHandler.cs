using GoodReadersClone.Application.Features.Authors.Queries;

namespace GoodReadersClone.Application.Features.Authors.Handlers;

public class GetAuthorBooksQueryHandler(

    IUnitOfWork _unitOfWork,
    UserManager<ApplicationUser> _userManager,
    IMapper _mapper)

    : IRequestHandler<GetAuthorBooksQuery, ApiResponse>
{
    public async Task<ApiResponse> Handle(GetAuthorBooksQuery request, CancellationToken cancellationToken)
    {
        var author = _unitOfWork.AuthorRepository.IsExist(x => x.Id == request.AuthorId);

        if (!_unitOfWork.AuthorRepository.IsExist(x => x.Id == request.AuthorId))
            return new ApiResponse { Message = "Author Not Found" };

        var authorBooks = await _unitOfWork.BookRepository.GetAllAsync(x => x.AuthorId == request.AuthorId);
  
        return new ApiResponse
        {
            Success = true,
            Data = authorBooks
        };
    }
}


