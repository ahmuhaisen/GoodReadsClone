using GoodReadersClone.Application.DTOs.Genre;

namespace GoodReadersClone.Application.Features.Genres.Commands;

public record CreateGenreCommand(GenreDto Dto) : IRequest<ApiResponse>;
public record EditGenreCommand(int Id, GenreDto Dto) : IRequest<ApiResponse>;
public record DeleteGenreCommand(int Id) : IRequest<ApiResponse>;
