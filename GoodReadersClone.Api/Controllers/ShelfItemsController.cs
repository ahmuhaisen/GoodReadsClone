namespace GoodReadersClone.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ShelfItemsController : ControllerBase
{
    [HttpGet]
    [Route("")]
    public async Task<IActionResult> Get(string readerId, int shelfId = 0) // if 0 all books with any status will be returned
    {
        return Forbid();
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> AddToShelf()
    {
        return Forbid();
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
