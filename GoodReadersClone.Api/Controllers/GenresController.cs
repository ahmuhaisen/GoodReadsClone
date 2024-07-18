using GoodReadersClone.Application.DTOs.Genre;
using GoodReadersClone.Application.Features.Genres.Commands;
using GoodReadersClone.Application.Features.Genres.Queries;

namespace GoodReadersClone.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class GenresController(ISender _sender) : ControllerBase
{
    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAsync()
    {
        var result = await _sender.Send(new GetAllGenresQuery());

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        var result = await _sender.Send(new GetGenreQuery(id));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> CreateAsync(GenreDto dto)
    {
        var result = await _sender.Send(new CreateGenreCommand(dto));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> EditAsync(int id, GenreDto dto)
    {
        return Forbid();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return Forbid();
    }
}
