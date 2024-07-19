using Asp.Versioning;
using GoodReadersClone.Application.DTOs;
using GoodReadersClone.Application.Features.Books.Commands;
using GoodReadersClone.Application.Features.Books.Queries;
using GoodReadersClone.Infrastructure.Utils;

namespace GoodReadersClone.Api.Controllers.v1;


[ApiController]
[ApiVersion(1)]
[Route("api/v{version:apiVersion}/[controller]")]
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

        if (!result.Success)
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
    [Authorize(Roles = Roles.AUTHOR)]
    public async Task<ActionResult<ApiResponse>> Create([FromForm] CreateBookRequest request)
    {
        request.AuthorId = User.FindFirst("uid")!.Value;

        var result = await _sender.Send(new CreateBookCommand(request));

        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result);
    }

    [HttpPut]
    [Route("{bookId}")]
    [Authorize(Roles = Roles.AUTHOR)]
    public async Task<ActionResult<ApiResponse>> Edit(int bookId, [FromForm] EditBookRequest request)
    {
        var result = await _sender.Send(new EditBookCommand(bookId, request));

        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result);
    }

    [HttpDelete]
    [Route("{bookId}")]
    [Authorize(Roles = Roles.ADMIN)]
    public async Task<ActionResult<ApiResponse>> Delete(int bookId)
    {
        var result = await _sender.Send(new DeleteBookCommand(bookId));

        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result);
    }
}

