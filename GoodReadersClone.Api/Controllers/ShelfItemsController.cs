using GoodReadersClone.Application.DTOs.ShelfItem;
using GoodReadersClone.Application.Features.ShelfItems.Commands;
using GoodReadersClone.Application.Features.ShelfItems.Queries;
using GoodReadersClone.Domain.Enums;

namespace GoodReadersClone.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ShelfItemsController(ISender _sender) : ControllerBase
{
    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAll(string readerId)
    {
        var result = await _sender.Send(new GetAllShelfItemsQuery(readerId));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> AddToShelf(AddToShelfRequest request)
    {
        var result = await _sender.Send(new AddToShelfCommand(request));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpPut]
    [Route("")]
    public async Task<IActionResult> ChangeShelf()
    {
        return Forbid();
    }

    [HttpDelete]
    [Route("")]
    public async Task<IActionResult> Delete()
    {
        return Forbid();
    }

}
