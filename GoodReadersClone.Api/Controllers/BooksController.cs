using GoodReadersClone.Application.DTOs;
using GoodReadersClone.Application.DTOs.Books;
using GoodReadersClone.Application.Features.Books.Queries;

namespace GoodReadersClone.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController(ISender _sender) : ControllerBase
{
    [HttpGet]
    [Route("getAll")]
    public async Task<ActionResult<ApiResponse>> GetAll(GetAllBooksRequest request)
    {
        var result = await _sender.Send(new GetAllBooksQuery(request)); 

        return Ok(result);
    }

  


}
