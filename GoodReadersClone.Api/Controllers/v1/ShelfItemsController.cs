using GoodReadsClone.Application.Features.ShelfItems.Commands;
using GoodReadsClone.Application.Features.ShelfItems.Queries;
using GoodReadsClone.Application.DTOs.ShelfItem;

namespace GoodReadsClone.Api.Controllers.v1;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[Authorize(Roles = Roles.READER)]
public class ShelfItemsController(ISender _sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var readerId = User.FindFirst("uid")!.Value;

        var result = await _sender.Send(new GetAllShelfItemsQuery(readerId));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ShelfRequest request)
    {
        request.ReaderId = User.FindFirst("uid")!.Value;

        var result = await _sender.Send(new AddToShelfCommand(request));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] ShelfRequest request)
    {
        request.ReaderId = User.FindFirst("uid")!.Value;

        var result = await _sender.Send(new ChangeShelfCommand(request));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpDelete]
    [Route("{bookId}")]
    public async Task<IActionResult> Delete(int bookId)
    {
        var readerId = User.FindFirst("uid")!.Value;

        var result = await _sender.Send(new DeleteShelfItemCommand(readerId, bookId));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }
}
