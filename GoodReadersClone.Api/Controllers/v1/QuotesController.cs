using GoodReadersClone.Application.DTOs.Quote;
using GoodReadersClone.Application.Features.Quotes.Commands;
using GoodReadersClone.Application.Features.Quotes.Queries;

namespace GoodReadersClone.Api.Controllers.v1;


[Authorize]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class QuotesController(ISender _sender) : ControllerBase
{
    [HttpGet]
    [Route("reader/{readerId}")]
    public async Task<ActionResult> GetByUser(string readerId)
    {
        var result = await _sender.Send(new GetUserQuotesQuery(readerId));

        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result);
    }

    [HttpGet]
    [Route("book/{bookId}")]
    public async Task<ActionResult> GetByBook(int bookId)
    {
        var result = await _sender.Send(new GetBookQuotesQuery(bookId));

        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles = Roles.READER)]
    public async Task<ActionResult> Create([FromBody] QuoteDto model)
    {
        model.UserId = User.FindFirst("uid")!.Value;

        var result = await _sender.Send(new CreateQuoteCommand(model));

        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result);
    }

    [HttpDelete]
    [Route("{id}")]
    [Authorize(Roles = Roles.READER)]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _sender.Send(new DeleteQuoteCommand(id));

        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result);
    }
}
