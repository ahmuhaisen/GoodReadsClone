using Asp.Versioning;
using FluentValidation;
using GoodReadsClone.Application.Features.Books.Commands;
using GoodReadsClone.Application.Features.Books.Queries;

namespace GoodReadsClone.Api.Controllers.v1;


[ApiController]
[ApiVersion(1)]
[Route("api/v{version:apiVersion}/[controller]")]
public class BooksController(ISender _sender, IValidator<CreateBookCommand> _validator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string? searchTerm, [FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10)
    {
        var result = await _sender.Send(new GetAllBooksQuery(searchTerm, pageIndex, pageSize));

        return Ok(result);
    }

    [HttpGet]
    [Route("{bookId}")]
    public async Task<ActionResult> GetValue(int bookId)
    {
        var result = await _sender.Send(new GetBookByIdQuery(bookId));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpGet]
    [Route("isbn/{isbn}")]
    public async Task<ActionResult> GetByISBN(string isbn)
    {
        var result = await _sender.Send(new GetBookByISBNQuery(isbn));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpPost]
    //[Authorize(Roles = Roles.AUTHOR)]
    public async Task<IResult> Post([FromForm] CreateBookRequest request)
    {
        //request.AuthorId = User.FindFirst("uid")!.Value;

        var command = new CreateBookCommand(request);

        var validationResult = await _validator.ValidateAsync(command);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.ToDictionary();
            return Results.ValidationProblem(errors);
        }

        var result = await _sender.Send(command);

        if (!result.Success)
            return Results.BadRequest(result.Message);

        return Results.Created("", result);
    }

    [HttpPut]
    [Route("{bookId}")]
    [Authorize(Roles = Roles.AUTHOR)]
    public async Task<ActionResult> Put(int bookId, [FromForm] EditBookRequest request)
    {
        var result = await _sender.Send(new EditBookCommand(bookId, request));

        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result);
    }

    [HttpDelete]
    [Route("{bookId}")]
    [Authorize(Roles = Roles.ADMIN)]
    public async Task<ActionResult> Delete(int bookId)
    {
        var result = await _sender.Send(new DeleteBookCommand(bookId));

        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result);
    }
}

