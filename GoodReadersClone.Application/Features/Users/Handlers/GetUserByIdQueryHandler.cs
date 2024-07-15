using GoodReadersClone.Application.DTOs.User;
using GoodReadersClone.Application.Features.Users.Queries;

namespace GoodReadersClone.Application.Features.Users.Handlers;
public class GetUserByIdQueryHandler (UserManager<ApplicationUser> _userManager, IMapper _mapper)
    : IRequestHandler<GetUserByIdQuery, UserInfoModel>
{
    public async Task<UserInfoModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        if (request == null || string.IsNullOrEmpty(request.UserId))
            return new UserInfoModel { Message = "User Id cann't be null" };

        var user = await _userManager.FindByIdAsync(request.UserId);

        if (user is null)
            return new UserInfoModel { Message = "User not found" };

        var model = _mapper.Map<UserInfoModel>(user);

        model.Roles = (await _userManager.GetRolesAsync(user)).ToArray();
        
        return model;
    }
}
