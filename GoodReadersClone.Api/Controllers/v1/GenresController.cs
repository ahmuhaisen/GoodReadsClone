using GoodReadersClone.Application.DTOs.Genre;
using GoodReadersClone.Application.Features.Genres.Commands;
using GoodReadersClone.Application.Features.Genres.Queries;
using GoodReadersClone.Infrastructure.Helpers;

namespace GoodReadersClone.Api.Controllers.v1;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[Authorize(Roles = Roles.ADMIN)]
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
        var result = await _sender.Send(new EditGenreCommand(id, dto));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _sender.Send(new DeleteGenreCommand(id));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }
}
