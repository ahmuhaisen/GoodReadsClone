namespace GoodReadersClone.Application.DTOs.Auth;
public class RevokeTokenRequest
{
    // Not required, can be reached by cookies
    public string? Token { get; set; }
}
