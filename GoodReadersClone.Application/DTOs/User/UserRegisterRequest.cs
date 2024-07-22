using GoodReadersClone.Application.Attributes;
using System.ComponentModel.DataAnnotations;

namespace GoodReadsClone.Application.DTOs.User;

public class UserRegisterRequest
{
    [MinLength(5)]
    public required string UserName { get; set; }

    [MaxLength(50)]
    public required string Password { get; set; }

    [MinLength(3)]
    public required string FirstName { get; set; }

    [MinLength(3)]
    public required string LastName { get; set; }

    [DataType(DataType.Date)]
    public required DateTime DateOfBirth { get; set; }

    [ReputableEmail]
    [EmailAddress]
    public required string Email { get; set; }

    public IFormFile? ProfilePicture { get; set; }
}
