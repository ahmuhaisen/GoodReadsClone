using GoodReadersClone.Infrastructure.Helpers;
using System.Transactions;

namespace GoodReadersClone.Application.Features.Users.Handlers;


public class SetUserAsAuthorCommandHandler(
    UserManager<ApplicationUser> _userManager,
    RoleManager<IdentityRole> _roleManager)
    : IRequestHandler<SetUserAsAuthorCommand, UserModel>
{
    public async Task<UserModel> Handle(SetUserAsAuthorCommand request, CancellationToken cancellationToken)
    {
        if (request == null || string.IsNullOrEmpty(request.UserId))
            return new UserModel { Message = "User Id cann't be null" };

        var user = await _userManager.FindByIdAsync(request.UserId);

        if(user is null)
            return new UserModel { Message = "User not found" };

        var userRoles = await _userManager.GetRolesAsync(user);

        if(userRoles.Contains(Roles.AUTHOR))
            return new UserModel { Message = "User is already an AUTHOR" };

        if (userRoles.Contains(Roles.ADMIN))
            return new UserModel { Message = "ADMIN cann't be an AUTHOR" };

        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            var removeRolesResult = await _userManager.RemoveFromRolesAsync(user, userRoles);
            if (!removeRolesResult.Succeeded)
                return new UserModel { Message = "Failed to remove existing roles" };

            var addRoleResult = await _userManager.AddToRoleAsync(user, Roles.AUTHOR);
            if (!addRoleResult.Succeeded)
                return new UserModel { Message = "Failed to add AUTHOR role" };

            scope.Complete();
        }

        return new UserModel 
        {
            Message = "User successfully set as AUTHOR",
            Id = request.UserId,
            Roles = (await _userManager.GetRolesAsync(user)).ToArray()
        };
    }
}
