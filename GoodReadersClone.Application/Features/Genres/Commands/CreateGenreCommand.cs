using GoodReadersClone.Application.DTOs.Genre;

namespace GoodReadersClone.Application.Features.Genres.Commands;

public record CreateGenreCommand(GenreDto Dto) : IRequest<ApiResponse>;
