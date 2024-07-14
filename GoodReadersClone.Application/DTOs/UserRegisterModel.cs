using Microsoft.AspNetCore.Http;

namespace GoodReadersClone.Application.DTOs;

public class UserRegisterRequest
{
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required DateTime DateOfBirth { get; set; }
    public required string Email { get; set; }
    public IFormFile? ProfilePicture { get; set; }
}

public class UsersModel
{
    public string? Message{ get; set; }
    public string? Id { get; set; }
    public string? UserName { get; set; }
}
