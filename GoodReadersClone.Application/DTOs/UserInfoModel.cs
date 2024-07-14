using Microsoft.AspNetCore.Http;

namespace GoodReadersClone.Application.DTOs;
public class UserInfoModel
{
    public string Message{ get; set; }
    public string UserName{ get; set; }
    public string FirstName{ get; set; }
    public string LastName{ get; set; }
    public string DateOfBirth{ get; set; }
    public string Email{ get; set; }
    public string[] Roles{ get; set; }
    public IFormFile? ProfilePicture{ get; set; }
}
