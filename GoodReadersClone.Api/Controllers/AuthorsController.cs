namespace GoodReadersClone.Api.Controllers;


[ApiController]
[Route("authors")]
public class AuthorsController(ISender _sender)
{
    [HttpPost]
    [Route("getAuthorInfo")]
    [AllowAnonymous]
    public async Task<ActionResult<AuthorInfoModel>> GetAuthor(AuthorInfoRequest request)
    {
        var result = await _sender.Send(new GetAuthorInfoByIdQuery(request));
        return result;
    }

    [HttpGet]
    [Route("getAll")]
    public async Task<ActionResult<IEnumerable<UserInfoModel>>> GetAllAuthors()
    {
        var result = await _sender.Send(new GetAllAuthorsQuery());
        return result.ToList();
    }
}
