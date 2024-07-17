using GoodReadersClone.Application.DTOs;
using GoodReadersClone.Application.DTOs.Books;
using GoodReadersClone.Application.Features.Books.Commands;
using GoodReadersClone.Application.Features.Books.Queries;

namespace GoodReadersClone.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController(ISender _sender) : ControllerBase
{
    [HttpGet]
    [Route("getAll")]
    public async Task<ActionResult<ApiResponse>> GetAll(int pageIndex = 1, int pageSize = 10)
    {
        var result = await _sender.Send(new GetAllBooksQuery(pageIndex, pageSize)); 

        return Ok(result);
    }

    [HttpGet]
    [Route("getById")]
    public async Task<ActionResult<ApiResponse>> GetById(int bookId)
    {
        var result = await _sender.Send(new GetBookByIdQuery(bookId));

        if(!result.Success) 
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpGet]
    [Route("getByISBN")]
    public async Task<ActionResult<ApiResponse>> GetByISBN(string isbn)
    {
        var result = await _sender.Send(new GetBookByISBNQuery(isbn));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult<ApiResponse>> Create([FromForm] CreateBookRequest request)
    {
        var result = await _sender.Send(new CreateBookCommand(request));

        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result);
    }

    [HttpPut]
    [Route("")]
    public async Task<ActionResult<ApiResponse>> Edit()
    {
        return Forbid();
    }

    [HttpDelete]
    [Route("")]
    public async Task<ActionResult<ApiResponse>> Delete()
    {
        return Forbid();
    }
}
