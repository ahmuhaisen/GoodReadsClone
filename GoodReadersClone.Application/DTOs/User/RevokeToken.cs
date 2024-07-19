using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReadersClone.Application.DTOs.User;
public class RevokeToken
{
    // Not required, can be reached by cookies
    public string? Token { get; set; }
}
