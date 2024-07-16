namespace GoodReadersClone.Api.Controllers;


[ApiController]
[Route("[controller]")]
public class UsersController(ISender _sender) : ControllerBase
{
    [HttpPost]
    [Route("registerAsReader")]
    [AllowAnonymous]
    public async Task<ActionResult<UserModel>> RegisterAsReader([FromForm] UserRegisterRequest request)
    {
        var result = await _sender.Send(new CreateReaderCommand(request));
        return result;
    }

    [HttpPost]
    [Route("registerAsAuthor")]
    [AllowAnonymous]
    public async Task<ActionResult<UserModel>> RegisterAsAuthor([FromForm] UserRegisterRequest request)
    {
        var result = await _sender.Send(new CreateAuthorCommand(request));
        return result;
    }

    [HttpGet]
    [Route("getAll")]
    public async Task<ActionResult<IEnumerable<UserInfoModel>>> GetAll()
    {
        var result = await _sender.Send(new GetAllUsersQuery());
        return result.ToList();
    }

    [HttpGet]
    [Route("get/{userId}")]
    public async Task<ActionResult<UserInfoModel>> GetById(string userId)
    {
        var result = await _sender.Send(new GetUserByIdQuery(userId));
        return result;
    }
}
