namespace GoodReadersClone.Api.Controllers;


[ApiController]
[Route("[controller]")]
[AllowAnonymous]
public class AuthorsController(ISender _sender) : ControllerBase
{
    [HttpGet]
    [Route("{authorId}")]
    public async Task<IActionResult> Get(string authorId)
    {
        var result = await _sender.Send(new GetAuthorInfoByIdQuery(authorId));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _sender.Send(new GetAllAuthorsQuery());

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }


    [HttpGet]
    [Route("getBooks")]
    public async Task<IActionResult> GetBooks(string authorId)
    {
        var result = await _sender.Send(new GetAuthorBooksQuery(authorId));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }
}
