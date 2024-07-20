using System.Text.Json.Serialization;

namespace GoodReadersClone.Application.DTOs.Auth;
public class AuthenticationResponse
{
    public string Message { get; set; } = string.Empty;
    public bool IsAuthenticated { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public List<string> Roles { get; set; } = [];


    public string Token { get; set; } = string.Empty;
    //public DateTime ExpiresOn { get; set; }


    [JsonIgnore]
    public string? RefreshToken { get; set; }

    public DateTime RefreshTokenExpiration { get; set; }
}
