namespace GoodReadersClone.Api.Controllers.v1;


[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[Authorize]
public class UsersController(ISender _sender) : ControllerBase
{
    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _sender.Send(new GetAllUsersQuery());

        return Ok(result);
    }

    [HttpGet]
    [Route("{userId}")]
    public async Task<ActionResult> GetById(string userId)
    {
        var result = await _sender.Send(new GetUserByIdQuery(userId));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }
}
