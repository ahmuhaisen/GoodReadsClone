using GoodReadersClone.Application.DTOs;

namespace GoodReadersClone.Api.Controllers;


[ApiController]
[Route("[controller]")]
public class AuthorsController(ISender _sender) : ControllerBase
{
    [HttpGet]
    [Route("getAuthorInfo")]
    [AllowAnonymous]
    public async Task<ActionResult<ApiResponse>> GetAuthor(AuthorInfoRequest request)
    {
        var result = await _sender.Send(new GetAuthorInfoByIdQuery(request));

        if (!result.Success)
            return NotFound(result);

        return result;
    }

    [HttpGet]
    [Route("getAll")]
    public async Task<ActionResult<IEnumerable<UserInfoModel>>> GetAllAuthors()
    {
        var result = await _sender.Send(new GetAllAuthorsQuery());
        return Ok(result);
    }

    
}
