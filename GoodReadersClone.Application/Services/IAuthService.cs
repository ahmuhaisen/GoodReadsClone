namespace GoodReadersClone.Application.Services;
public interface IAuthService
{
    Task<AuthModel> RegisterAsync(UserRegisterRequest request, string role);

    Task<AuthModel> GetTokenAsync(TokenRequest request);

    Task<string> AddRoleAsync(AddRoleRequest model);

    Task<AuthModel> RefreshTokenAsync(string token);

    Task<bool> RevokeTokenAsync(string token);
}
