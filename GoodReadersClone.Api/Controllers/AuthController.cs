using GoodReadersClone.Application.Services;
using GoodReadersClone.Infrastructure.Helpers;

namespace GoodReadersClone.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(IAuthService _authService) : ControllerBase
{
    [HttpPost]
    [Route("registerAsReader")]
    [AllowAnonymous]
    public async Task<ActionResult> RegisterAsReader([FromForm] UserRegisterRequest request)
    {
        var result = await _authService.RegisterAsync(request, Roles.READER);

        if (!result.IsAuthenticated)
            return BadRequest(result.Message);

        return Ok(result);
    }


    [HttpPost]
    [Route("registerAsAuthor")]
    [AllowAnonymous]
    public async Task<ActionResult> RegisterAsAuthor([FromForm] UserRegisterRequest request)
    {
        var result = await _authService.RegisterAsync(request, Roles.AUTHOR);

        if (!result.IsAuthenticated)
            return BadRequest(result.Message);

        return Ok(result);
    }


    [HttpGet]
    [Route("token")]
    [AllowAnonymous]
    public async Task<ActionResult> GetToken(TokenRequest request)
    {
        var result = await _authService.GetTokenAsync(request);

        if (!result.IsAuthenticated)
            return BadRequest(result.Message);

        return Ok(result);
    }

    [HttpGet("addrole")]
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
