namespace GoodReadsClone.Application.Features.Genres.Queries;
public record GetAllGenresQuery() : IRequest<ApiResponse>;
public record GetGenreQuery(int Id) : IRequest<ApiResponse>;