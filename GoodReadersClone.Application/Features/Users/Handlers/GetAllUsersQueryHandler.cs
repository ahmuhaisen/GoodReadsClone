using GoodReadersClone.Application.Features.Users.Queries;

namespace GoodReadersClone.Application.Features.Users.Handlers;
public class GetAllReadersQueryHandler(UserManager<ApplicationUser> _userManager, IMapper _mapper)
    : IRequestHandler<GetAllUsersQuery, ApiResponse>
{
    public async Task<ApiResponse> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var allUsers = await _userManager.Users
            .Where(a => a.Discrimintator != Roles.AUTHOR)
            .ToListAsync();

        var result = _mapper.Map<IEnumerable<UserResponse>>(allUsers);

        return new ApiResponse
        {
            Success = true,
            Data = result
        };
    }
}

