using GoodReadersClone.Application.Features.Users.Queries;
using Microsoft.EntityFrameworkCore;

namespace GoodReadersClone.Application.Features.Users.Handlers;
public class GetAllUsersQueryHandler(UserManager<ApplicationUser> _userManager, IMapper _mapper)
    : IRequestHandler<GetAllUsersQuery, IEnumerable<UserInfoModel>>
{
    public async Task<IEnumerable<UserInfoModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var allUsers = await _userManager.Users.ToListAsync();

        var result = _mapper.Map<IEnumerable<UserInfoModel>>(allUsers);

        return result;
    }
}
