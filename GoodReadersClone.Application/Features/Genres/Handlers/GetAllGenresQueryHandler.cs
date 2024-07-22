using GoodReadsClone.Application.DTOs.Genre;
using GoodReadsClone.Application.Features.Genres.Queries;

namespace GoodReadsClone.Application.Features.Genres.Handlers;
public class GetAllGenresQueryHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<GetAllGenresQuery, ApiResponse>
{
    public async Task<ApiResponse> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
    {
        return new ApiResponse
        {
            Success = true,
            Data = _mapper.Map<IEnumerable<GenreDto>>(await _unitOfWork.GenreRepository.GetAllAsync())
        };
    }
}

public class GetGenreQueryHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<GetGenreQuery, ApiResponse>
{
    public async Task<ApiResponse> Handle(GetGenreQuery request, CancellationToken cancellationToken)
    {
        var genre = await _unitOfWork.GenreRepository.GetAsync(g => g.Id == request.Id);

        if (genre is null)
            return new ApiResponse { Message = $"Genre with Id `{request.Id}` Not Found" };

        return new ApiResponse
        {
            Success = true,
            Data = _mapper.Map<GenreDto>(genre)
        };
    }
}
