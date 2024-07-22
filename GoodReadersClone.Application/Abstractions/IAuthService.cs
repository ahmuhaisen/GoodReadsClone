namespace GoodReadsClone.Application.Abstractions;
public interface IAuthService
{
    Task<AuthenticationResponse> RegisterAsync(UserRegisterRequest request, string role);

    Task<AuthenticationResponse> GetTokenAsync(TokenRequest request);

    Task<string> AddRoleAsync(AddRoleRequest model);

    Task<AuthenticationResponse> RefreshTokenAsync(string? token);

    Task<bool> RevokeTokenAsync(string token);
}
