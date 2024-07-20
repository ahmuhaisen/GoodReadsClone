
namespace GoodReadersClone.Api.Helpers;

public class AuthenticationHelper
{
    public static void SetRefreshTokenInCookie(string refreshToken, DateTime expires, HttpResponse response)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = expires.ToLocalTime()
        };
        response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
    }
}
