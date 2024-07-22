using GoodReadsClone.Application.DTOs;
using GoodReadsClone.Application.Features.Genres.Commands;
using GoodReadsClone.Infrastructure.DataAccess.Abstractions;

namespace GoodReadsClone.Application.Features.Genres.Handlers;

public class DeleteGenreCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<DeleteGenreCommand, ApiResponse>
{
    public async Task<ApiResponse> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
    {
        var genre = await _unitOfWork.GenreRepository.GetAsync(g => g.Id == request.Id);

        if (genre is null)
            return new ApiResponse { Message = $"Genre with Id `{request.Id}` Not Found" };

        _unitOfWork.GenreRepository.Delete(genre);

        if (_unitOfWork.Save() == 0)
            return new ApiResponse { Message = "Error Occured" };

        return new ApiResponse
        {
            Success = true,
        };
    }
}