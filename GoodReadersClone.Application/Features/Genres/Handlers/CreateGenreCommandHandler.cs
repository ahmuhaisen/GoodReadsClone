using GoodReadsClone.Application.Features.Genres.Commands;

namespace GoodReadsClone.Application.Features.Genres.Handlers;

public class CreateGenreCommandHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<CreateGenreCommand, ApiResponse>
{
    public async Task<ApiResponse> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
    {
        if (await _unitOfWork.GenreRepository.IsExist(g => g.Name.ToLower() == request.Dto.Name.ToLower()))
            return new ApiResponse { Message = $"Genre with name `{request.Dto.Name.ToLower()}` already exists" };

        var genreToAdd = _mapper.Map<Genre>(request.Dto);

        _unitOfWork.GenreRepository.Create(genreToAdd);

        if (_unitOfWork.Save() == 0)
            return new ApiResponse { Message = "Error Occured" };

        return new ApiResponse
        {
            Success = true,
            Data = genreToAdd.Id
        };
    }
}
