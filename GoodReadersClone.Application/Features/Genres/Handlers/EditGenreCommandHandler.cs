using GoodReadsClone.Application.Features.Genres.Commands;

namespace GoodReadsClone.Application.Features.Genres.Handlers;

public class EditGenreCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<EditGenreCommand, ApiResponse>
{
    public async Task<ApiResponse> Handle(EditGenreCommand request, CancellationToken cancellationToken)
    {
        var genre = await _unitOfWork.GenreRepository.GetAsync(g => g.Id == request.Id);

        if (genre is null)
            return new ApiResponse { Message = $"Genre with Id `{request.Id}` Not Found" };

        if (await _unitOfWork.GenreRepository.IsExist(g => g.Name.ToLower() == request.Dto.Name.ToLower()))
            return new ApiResponse { Message = $"Genre with name `{request.Dto.Name}` already exist" };

        genre.Name = request.Dto.Name;

        _unitOfWork.GenreRepository.Update(genre);

        if (_unitOfWork.Save() == 0)
            return new ApiResponse { Message = "Error Occured" };

        return new ApiResponse
        {
            Success = true,
        };
    }
}
