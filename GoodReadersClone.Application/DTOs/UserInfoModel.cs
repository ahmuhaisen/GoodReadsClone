using Microsoft.AspNetCore.Http;

namespace GoodReadersClone.Application.DTOs;
public class UserInfoModel : UserModel
{
    public string FirstName{ get; set; }
    public string LastName{ get; set; }
    public string DateOfBirth{ get; set; }
    public string Email{ get; set; }
    public IFormFile? ProfilePicture{ get; set; }
}
