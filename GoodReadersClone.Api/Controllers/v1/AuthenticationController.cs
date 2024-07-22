using GoodReadersClone.Api.Helpers;
using GoodReadersClone.Application.Abstractions;

namespace GoodReadersClone.Api.Controllers.v1;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class AuthenticationController(IAuthService _authService) : ControllerBase
{
    [HttpPost]
    [Route("reader/register")]
    public async Task<ActionResult> RegisterAsReader([FromForm] UserRegisterRequest request)
    {
        var result = await _authService.RegisterAsync(request, Roles.READER);

        if (!result.IsAuthenticated)
            return BadRequest(result.Message);

        AuthenticationHelper.SetRefreshTokenInCookie(result.RefreshToken!, result.RefreshTokenExpiration, Response);

        return Ok(result);
    }


    [HttpPost]
    [Route("author/register")]
    public async Task<ActionResult> RegisterAsAuthor([FromForm] UserRegisterRequest request)
    {
        var result = await _authService.RegisterAsync(request, Roles.AUTHOR);

        if (!result.IsAuthenticated)
            return BadRequest(result.Message);

        AuthenticationHelper.SetRefreshTokenInCookie(result.RefreshToken!, result.RefreshTokenExpiration, Response);

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
            AuthenticationHelper.SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration, Response);

        return Ok(result);
    }


    [HttpGet("refreshtoken")]
    public async Task<IActionResult> RefreshToken()
    {
        var refreshToken = Request.Cookies["refreshToken"];

        var result = await _authService.RefreshTokenAsync(refreshToken);

        if (!result.IsAuthenticated)
            return BadRequest(result);

        AuthenticationHelper.SetRefreshTokenInCookie(result.RefreshToken!, result.RefreshTokenExpiration, Response);

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


    [HttpPost("role")]
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
}
