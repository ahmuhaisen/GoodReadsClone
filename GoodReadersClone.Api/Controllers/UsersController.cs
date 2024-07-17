namespace GoodReadersClone.Api.Controllers;


[ApiController]
[Route("[controller]")]
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

    [HttpPost]
    [Route("registerAsReader")]
    public async Task<ActionResult> RegisterAsReader([FromForm] UserRegisterRequest request)
    {
        var result = await _sender.Send(new CreateReaderCommand(request));

        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result);
    }

    [HttpPost]
    [Route("registerAsAuthor")]
    public async Task<ActionResult> RegisterAsAuthor([FromForm] UserRegisterRequest request)
    {
        var result = await _sender.Send(new CreateAuthorCommand(request));

        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result);
    }
}
