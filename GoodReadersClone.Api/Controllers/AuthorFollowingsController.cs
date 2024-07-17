using GoodReadersClone.Application.DTOs;
using GoodReadersClone.Application.DTOs.AuthorFollowing;
using GoodReadersClone.Application.Features.AuthorFollowings.Commands;
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
    [AllowAnonymous]
    public async Task<ActionResult<ApiResponse>> CreateFollowing(FollowingRequest request)
    {
        var result = await _sender.Send(new CreateFollowingCommand(request));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpDelete]
    [Route("unfollow")]
    [AllowAnonymous]
    public async Task<ActionResult<ApiResponse>> DeleteFollowing(FollowingRequest request)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState.ErrorCount);

        var result = await _sender.Send(new DeleteFollowingCommand(request));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }
}
