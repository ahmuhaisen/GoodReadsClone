using GoodReadersClone.Application.Features.AuthorFollowings.Queries;

namespace GoodReadersClone.Application.Features.AuthorFollowings.Handlers;
public class GetAuthorFollowersQueryHandler(IUnitOfWork _unitOfWork)
    : IRequestHandler<GetAuthorFollowersQuery, ApiResponse>
{
    public async Task<ApiResponse> Handle(GetAuthorFollowersQuery request, CancellationToken cancellationToken)
    {
        if (!_unitOfWork.AuthorRepository.IsExist(x => x.Id == request.AuthorId))
            return new ApiResponse { Message = "Author not found" };

        var followers = await _unitOfWork.AuthorFollowingRepository
                    .GetAllAsync(x => x.AuthorId == request.AuthorId, new[] {"ApplicationUser"});

        var result = followers.Select(x => UserResponse.ConvertApplicationUserToUserResponse(x.ApplicationUser));

        return new ApiResponse
        {
            Success = true,
            Data = result
        };
    }
}

