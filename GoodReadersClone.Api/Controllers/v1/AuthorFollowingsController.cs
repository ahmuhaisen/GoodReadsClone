using GoodReadersClone.Application.DTOs;
using GoodReadersClone.Application.DTOs.AuthorFollowing;
using GoodReadersClone.Application.Features.AuthorFollowings.Commands;
using GoodReadersClone.Application.Features.AuthorFollowings.Queries;
using GoodReadersClone.Infrastructure.Utils;

namespace GoodReadersClone.Api.Controllers.v1;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
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

    [HttpGet]
    [Route("getReaderFollowings")]
    [AllowAnonymous]
    public async Task<ActionResult<ApiResponse>> GetReaderFollowings(string readerId)
    {
        var result = await _sender.Send(new GetReaderFollowingsQuery(readerId));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpPost]
    [Route("follow")]
    [Authorize(Roles = Roles.READER)]
    public async Task<ActionResult<ApiResponse>> CreateFollowing(FollowingRequest request)
    {
        request.ReaderId = User.FindFirst("uid")!.Value;

        var result = await _sender.Send(new CreateFollowingCommand(request));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpDelete]
    [Route("unfollow")]
    [Authorize(Roles = Roles.READER)]
    public async Task<ActionResult<ApiResponse>> DeleteFollowing(FollowingRequest request)
    {
        request.ReaderId = User.FindFirst("uid")!.Value;

        var result = await _sender.Send(new DeleteFollowingCommand(request));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }
}
