using GoodReadersClone.Application.DTOs;
using GoodReadersClone.Application.Features.AuthorFollowings.Queries;

namespace GoodReadersClone.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorFollowingsController(ISender _sender) : ControllerBase
{
    [HttpGet]
    [Route("getAuthorFollowers")]
    [AllowAnonymous]
    public async Task<ActionResult<ApiResponse>> GetAuthorFollowers(string authorId)
    {
        var result = await _sender.Send(new GetAuthorFollowersQuery(authorId));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }
}
