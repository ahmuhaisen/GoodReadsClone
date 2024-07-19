using GoodReadersClone.Application.DTOs.User;

namespace GoodReadersClone.Application.Services;
public interface IAuthService
{
    Task<AuthModel> RegisterAsync(UserRegisterRequest request, string role));
}
