namespace GoodReadersClone.Api.Controllers.v1;


//[Authorize]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class UsersController(ISender _sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _sender.Send(new GetAllUsersQuery());

        return Ok(result);
    }

    [HttpGet]
    [Route("{userId}")]
    public async Task<ActionResult> GetValue(string userId)
    {
        var result = await _sender.Send(new GetUserByIdQuery(userId));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }
}
