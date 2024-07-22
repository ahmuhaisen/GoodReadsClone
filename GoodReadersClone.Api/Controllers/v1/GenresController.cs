using GoodReadsClone.Application.Features.Genres.Commands;
using GoodReadsClone.Application.Features.Genres.Queries;
using GoodReadsClone.Application.DTOs.Genre;

namespace GoodReadsClone.Api.Controllers.v1;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
//[Authorize(Roles = Roles.ADMIN)]
public class GenresController(ISender _sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _sender.Send(new GetAllGenresQuery());

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetValue(int id)
    {
        var result = await _sender.Send(new GetGenreQuery(id));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] GenreDto dto)
    {
        var result = await _sender.Send(new CreateGenreCommand(dto));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] GenreDto dto)
    {
        var result = await _sender.Send(new EditGenreCommand(id, dto));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _sender.Send(new DeleteGenreCommand(id));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }
}
