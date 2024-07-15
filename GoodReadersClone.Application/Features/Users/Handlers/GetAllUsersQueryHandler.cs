using GoodReadersClone.Application.DTOs.User;
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

