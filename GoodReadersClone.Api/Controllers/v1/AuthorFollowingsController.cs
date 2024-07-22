using GoodReadsClone.Application.Features.AuthorFollowings.Commands;
using GoodReadsClone.Application.Features.AuthorFollowings.Queries;
using GoodReadsClone.Application.DTOs.AuthorFollowing;

namespace GoodReadsClone.Api.Controllers.v1;

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
    public async Task<ActionResult> Post([FromBody] FollowRequest request)
    {
        request.ReaderId = User.FindFirst("uid")!.Value;

        var result = await _sender.Send(new CreateFollowingCommand(request));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpDelete]
    [Authorize(Roles = Roles.READER)]
    public async Task<ActionResult> Delete([FromBody] FollowRequest request)
    {
        request.ReaderId = User.FindFirst("uid")!.Value;

        var result = await _sender.Send(new DeleteFollowingCommand(request));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }
}
