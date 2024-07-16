using GoodReadersClone.Application.DTOs;
using GoodReadersClone.Application.DTOs.Quote;
using GoodReadersClone.Application.Features.Quotes.Commands;

namespace GoodReadersClone.Api.Controllers;


[ApiController]
[Route("[controller]")]
public class QuotesController(ISender _sender) : ControllerBase
{
    [HttpPost]
    [Route("")]
    public async Task<ActionResult<ApiResponse>> Create(QuoteModel model)
    {
        var result = await _sender.Send(new CreateQuoteCommand(model));

        if(!result.Success)
            return BadRequest(result.Message);

        return Ok(result);
    }

    [HttpDelete]
    [Route("")]
    public async Task<ActionResult<ApiResponse>> Delete(int id)
    {
        var result = await _sender.Send(new DeleteQuoteCommand(id));

        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result);
    }
}
