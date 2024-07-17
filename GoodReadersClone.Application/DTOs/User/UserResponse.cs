using Microsoft.AspNetCore.Http;

namespace GoodReadersClone.Application.DTOs.User;
public class UserResponse
{
    public required string UserName { get; set; }
    public required string FullName { get; set; }
    public required string DateOfBirth { get; set; }
    public required string Email { get; set; }
    public string? ProfilePicture { get; set; }

    public static UserResponse ConvertApplicationUserToUserResponse(ApplicationUser user)
    {
        return new UserResponse
        {
            UserName = user.UserName!,
            FullName = $"{user.FirstName!} {user.LastName!}",
            Email = user.Email!,
            DateOfBirth = user.DateOfBirth.ToShortDateString(),
            ProfilePicture = user.ProfilePectureURL
        };
    }
}
