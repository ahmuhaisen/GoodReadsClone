using GoodReadersClone.Application.DTOs.User;
using GoodReadersClone.Application.Features.Authors.Queries;
using GoodReadersClone.Infrastructure.DataAccess.Abstractions;

namespace GoodReadersClone.Application.Features.Authors.Handlers;
public class GetAllAuthorsQueryHandler(

    IUnitOfWork _unitOfWork,
    UserManager<ApplicationUser> _userManager,
    IMapper _mapper)

    : IRequestHandler<GetAllAuthorsQuery, IEnumerable<UserInfoModel>>
{
    public async Task<IEnumerable<UserInfoModel>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
    {
        var allAuthors = await _unitOfWork.AuthorRepository.GetAllAsync();

        var result = _mapper.Map<IEnumerable<UserInfoModel>>(allAuthors);

        return result;
    }
}


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
  
        return new ApiResponse { Success = true, Data = authorBooks};
    }
}


