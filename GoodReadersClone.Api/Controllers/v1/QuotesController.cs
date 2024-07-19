using GoodReadersClone.Application.DTOs;
using GoodReadersClone.Application.DTOs.Quote;
using GoodReadersClone.Application.Features.Quotes.Commands;
using GoodReadersClone.Application.Features.Quotes.Queries;
using GoodReadersClone.Infrastructure.Utils;

namespace GoodReadersClone.Api.Controllers.v1;


[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[Authorize]
public class QuotesController(ISender _sender) : ControllerBase
{
    [HttpGet]
    [Route("getByUserId")]
    public async Task<ActionResult<ApiResponse>> GetByUser(string id)
    {
        var result = await _sender.Send(new GetUserQuotesQuery(id));

        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result);
    }

    [HttpGet]
    [Route("getByBookId")]
    [Authorize]
    public async Task<ActionResult<ApiResponse>> GetByBook(int id)
    {
        var result = await _sender.Send(new GetBookQuotesQuery(id));

        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result);
    }

    [HttpPost]
    [Route("")]
    [Authorize(Roles = Roles.READER)]
    public async Task<ActionResult<ApiResponse>> Create(QuoteModel model)
    {
        model.UserId = User.FindFirst("uid")!.Value;

        var result = await _sender.Send(new CreateQuoteCommand(model));

        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result);
    }

    [HttpDelete]
    [Route("")]
    [Authorize(Roles = Roles.READER)]
    public async Task<ActionResult<ApiResponse>> Delete(int id)
    {
        var result = await _sender.Send(new DeleteQuoteCommand(id));

        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result);
    }
}
