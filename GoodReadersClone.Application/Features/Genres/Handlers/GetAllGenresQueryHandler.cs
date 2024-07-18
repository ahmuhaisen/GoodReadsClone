using GoodReadersClone.Application.DTOs.Genre;
using GoodReadersClone.Application.Features.Genres.Commands;
using GoodReadersClone.Application.Features.Genres.Queries;

namespace GoodReadersClone.Application.Features.Genres.Handlers;
public class GetAllGenresQueryHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<GetAllGenresQuery, ApiResponse>
{
    public async Task<ApiResponse> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
    {
        return new ApiResponse
        {
            Success = true,
            Data = _mapper.Map<IEnumerable<GenreDto>>((await _unitOfWork.GenreRepository.GetAllAsync())) 
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


public class CreateGenreCommandHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<CreateGenreCommand, ApiResponse>
{
    public async Task<ApiResponse> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
    {       
        if (await _unitOfWork.GenreRepository.IsExist(g => g.Name.ToLower() == request.Dto.Name.ToLower()))
            return new ApiResponse { Message = $"Genre with name `{request.Dto.Name.ToLower()}` already exists" };

        var genreToAdd = _mapper.Map<Genre>(request.Dto);

        _unitOfWork.GenreRepository.Create(genreToAdd);
        
        if(_unitOfWork.Save() == 0)
            return new ApiResponse { Message = "Error Occured" };

        return new ApiResponse
        {
            Success = true,
            Data = genreToAdd.Id
        };
    }
}