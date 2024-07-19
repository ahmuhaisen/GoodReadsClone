using System.ComponentModel.DataAnnotations;

namespace GoodReadersClone.Application.DTOs.User;

public class TokenRequest
{
    [DataType(DataType.EmailAddress)]
    public required string Email { get; set; }

    [MinLength(6)]
    public required string Password { get; set; }
}
