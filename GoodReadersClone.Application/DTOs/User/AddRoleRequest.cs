using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReadersClone.Application.DTOs.User;
public class AddRoleRequest
{
    public required string UserId { get; set; }

    [AllowedValues(Roles.ADMIN)]
    public required string Role { get; set; }
}
