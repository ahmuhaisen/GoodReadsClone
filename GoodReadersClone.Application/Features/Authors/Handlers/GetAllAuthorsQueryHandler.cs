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


