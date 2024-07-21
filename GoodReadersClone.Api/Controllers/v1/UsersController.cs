namespace GoodReadersClone.Api.Controllers.v1;


//[Authorize]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class UsersController(ISender _sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string? searchTerm, [FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10)
    {
        var result = await _sender
            .Send(new GetAllUsersQuery(searchTerm, pageIndex, pageSize));

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
