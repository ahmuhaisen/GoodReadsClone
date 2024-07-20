namespace GoodReadersClone.Api.Controllers.v1;


[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[AllowAnonymous]
public class AuthorsController(ISender _sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _sender.Send(new GetAllAuthorsQuery());

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }



    [HttpGet]
    [Route("{authorId}")]
    public async Task<IActionResult> GetValue(string authorId)
    {
        var result = await _sender.Send(new GetAuthorInfoByIdQuery(authorId));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

  

    [HttpGet]
    [Route("books/{authorId}")]
    public async Task<IActionResult> GetBooks(string authorId)
    {
        var result = await _sender.Send(new GetAuthorBooksQuery(authorId));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }
}
