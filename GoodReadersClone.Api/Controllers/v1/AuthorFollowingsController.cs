using GoodReadersClone.Application.DTOs.AuthorFollowing;
using GoodReadersClone.Application.Features.AuthorFollowings.Commands;
using GoodReadersClone.Application.Features.AuthorFollowings.Queries;

namespace GoodReadersClone.Api.Controllers.v1;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class AuthorFollowingsController(ISender _sender) : ControllerBase
{
    [HttpGet]
    [Route("authorFollowers/{authorId}")]
    public async Task<ActionResult> GetAuthorFollowers(string authorId)
    {
        var result = await _sender.Send(new GetAuthorFollowersQuery(authorId));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpGet]
    [Route("readerFollowings/{readerId}")]
    public async Task<ActionResult> GetReaderFollowings(string readerId)
    {
        var result = await _sender.Send(new GetReaderFollowingsQuery(readerId));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles = Roles.READER)]
    public async Task<ActionResult> Post([FromBody] FollowingRequest request)
    {
        request.ReaderId = User.FindFirst("uid")!.Value;

        var result = await _sender.Send(new CreateFollowingCommand(request));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpDelete]
    [Authorize(Roles = Roles.READER)]
    public async Task<ActionResult> Delete([FromBody] FollowingRequest request)
    {
        request.ReaderId = User.FindFirst("uid")!.Value;

        var result = await _sender.Send(new DeleteFollowingCommand(request));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }
}
