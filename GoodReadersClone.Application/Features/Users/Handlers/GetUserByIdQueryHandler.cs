using GoodReadersClone.Application.Features.Users.Queries;

namespace GoodReadersClone.Application.Features.Users.Handlers;
public class GetUserByIdQueryHandler (
    UserManager<ApplicationUser> _userManager,
    IMapper _mapper)
    : IRequestHandler<GetUserByIdQuery, ApiResponse>
{
    public async Task<ApiResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        if (request == null || string.IsNullOrEmpty(request.UserId))
            return new ApiResponse { Message = "User Id cann't be null" };

        var user = await _userManager.FindByIdAsync(request.UserId);

        if (user is null)
            return new ApiResponse { Message = "User not found" };

        var result = _mapper.Map<UserResponse>(user);

        result.Roles = (await _userManager.GetRolesAsync(user)).ToArray();
        
        return new ApiResponse
        {
            Success = true,
            Data = result
        };
    }
}
