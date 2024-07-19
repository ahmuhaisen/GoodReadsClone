using GoodReadersClone.Infrastructure.Utils;

namespace GoodReadersClone.Api.Controllers.v1;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class AuthController(IAuthService _authService) : ControllerBase
{
    [HttpPost]
    [Route("registerAsReader")]
    public async Task<ActionResult> RegisterAsReader([FromForm] UserRegisterRequest request)
    {
        var result = await _authService.RegisterAsync(request, Roles.READER);

        if (!result.IsAuthenticated)
            return BadRequest(result.Message);

        SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);

        return Ok(result);
    }


    [HttpPost]
    [Route("registerAsAuthor")]
    public async Task<ActionResult> RegisterAsAuthor([FromForm] UserRegisterRequest request)
    {
        var result = await _authService.RegisterAsync(request, Roles.AUTHOR);

        if (!result.IsAuthenticated)
            return BadRequest(result.Message);

        SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);

        return Ok(result);
    }


    [HttpGet]
    [Route("token")]
    public async Task<ActionResult> GetToken(TokenRequest request)
    {
        var result = await _authService.GetTokenAsync(request);

        if (!result.IsAuthenticated)
            return BadRequest(result.Message);

        if (!string.IsNullOrEmpty(result.RefreshToken))
            SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);

        return Ok(result);
    }


    [HttpGet("refreshtoken")]
    public async Task<IActionResult> RefreshToken()
    {
        var refreshToken = Request.Cookies["refreshToken"];

        var result = await _authService.RefreshTokenAsync(refreshToken);

        if (!result.IsAuthenticated)
            return BadRequest(result);

        SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);

        return Ok(result);
    }


    [HttpPost("revoketoken")]
    public async Task<IActionResult> RevokeToken([FromBody] RevokeTokenRequest model)
    {
        var token = model.Token ?? Request.Cookies["refreshToken"];

        if (string.IsNullOrEmpty(token))
            return BadRequest("Token is required");

        var result = await _authService.RevokeTokenAsync(token);

        return result ? Ok() : BadRequest("Token is invalid");
    }


    [HttpPost("addrole")]
    [Authorize(Roles = Roles.ADMIN)]
    public async Task<IActionResult> AddRole(AddRoleRequest model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _authService.AddRoleAsync(model);

        if (!string.IsNullOrEmpty(result))
            return BadRequest(result);

        return Ok(model);
    }


    private void SetRefreshTokenInCookie(string refreshToken, DateTime expires)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = expires.ToLocalTime()
        };
        Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
    }
}
