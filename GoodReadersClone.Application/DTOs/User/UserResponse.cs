using Microsoft.AspNetCore.Http;

namespace GoodReadersClone.Application.DTOs.User;
public class UserResponse
{
    public required string UserName { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string DateOfBirth { get; set; }
    public required string Email { get; set; }
    public string? ProfilePicture { get; set; }

    public static UserResponse ConvertApplicationUserToUserResponse(ApplicationUser user)
    {
        return new UserResponse
        {
            UserName = user.UserName!,
            FirstName = user.FirstName!,
            LastName = user.LastName!,
            Email = user.Email!,
            DateOfBirth = user.DateOfBirth.ToShortDateString(),
            ProfilePicture = user.ProfilePectureURL
        };
    }
}
