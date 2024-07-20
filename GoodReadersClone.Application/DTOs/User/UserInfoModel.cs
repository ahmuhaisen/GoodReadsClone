namespace GoodReadersClone.Application.DTOs.User;
public class UserInfoModel : UserModel
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string DateOfBirth { get; set; }
    public required string Email { get; set; }
    public IFormFile? ProfilePicture { get; set; }
}
