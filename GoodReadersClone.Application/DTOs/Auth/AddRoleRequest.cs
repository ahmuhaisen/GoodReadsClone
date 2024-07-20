using System.ComponentModel.DataAnnotations;

namespace GoodReadersClone.Application.DTOs.Auth;
public class AddRoleRequest
{
    public required string UserId { get; set; }

    [AllowedValues(Roles.ADMIN)]
    public required string Role { get; set; }
}
