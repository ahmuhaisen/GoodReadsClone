using GoodReadersClone.Application.Features.Users.Queries;
using GoodReadersClone.Infrastructure.DataAccess.Abstractions;
using GoodReadersClone.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;

namespace GoodReadersClone.Application.Features.Users.Handlers;
public class GetAllReadersQueryHandler(UserManager<ApplicationUser> _userManager, IMapper _mapper)
    : IRequestHandler<GetAllUsersQuery, IEnumerable<UserInfoModel>>
{
    public async Task<IEnumerable<UserInfoModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var allUsers = await _userManager.Users
            .Where(a => a.Discrimintator != Roles.AUTHOR)
            .ToListAsync();

        var result = _mapper.Map<IEnumerable<UserInfoModel>>(allUsers);

        return result;
    }
}


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