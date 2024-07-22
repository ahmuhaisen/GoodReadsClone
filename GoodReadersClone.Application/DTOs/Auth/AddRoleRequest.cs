using GoodReadsClone.Infrastructure.Utils;
using System.ComponentModel.DataAnnotations;

namespace GoodReadsClone.Application.DTOs.Auth;
public class AddRoleRequest
{
    public required string UserId { get; set; }

    [AllowedValues(Roles.ADMIN)]
    public required string Role { get; set; }
}
