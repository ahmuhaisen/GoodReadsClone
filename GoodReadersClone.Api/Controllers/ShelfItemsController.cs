using GoodReadersClone.Application.DTOs.ShelfItem;
using GoodReadersClone.Application.Features.ShelfItems.Commands;
using GoodReadersClone.Application.Features.ShelfItems.Queries;
using GoodReadersClone.Infrastructure.Helpers;

namespace GoodReadersClone.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Roles = Roles.READER)]
public class ShelfItemsController(ISender _sender) : ControllerBase
{
    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAll()
    {
        var readerId = User.FindFirst("uid")!.Value;
        
        var result = await _sender.Send(new GetAllShelfItemsQuery(readerId));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> AddToShelf(ShelfRequest request)
    {
        request.ReaderId = User.FindFirst("uid")!.Value;
        
        var result = await _sender.Send(new AddToShelfCommand(request));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpPut]
    [Route("")]
    public async Task<IActionResult> ChangeShelf(ShelfRequest request)
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
