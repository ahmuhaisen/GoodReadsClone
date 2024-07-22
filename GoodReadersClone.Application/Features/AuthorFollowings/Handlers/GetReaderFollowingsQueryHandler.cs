using GoodReadsClone.Application.DTOs;
using GoodReadsClone.Application.DTOs.Author;
using GoodReadsClone.Application.Features.AuthorFollowings.Queries;
using GoodReadsClone.Domain.Entities;
using GoodReadsClone.Infrastructure.DataAccess.Abstractions;
using GoodReadsClone.Infrastructure.Utils;

namespace GoodReadsClone.Application.Features.AuthorFollowings.Handlers;

public class GetReaderFollowingsQueryHandler(
    IUnitOfWork _unitOfWork,
    UserManager<ApplicationUser> _userManager)
    : IRequestHandler<GetReaderFollowingsQuery, ApiResponse>
{
    public async Task<ApiResponse> Handle(GetReaderFollowingsQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.ReaderId);

        if (user is null)
            return new ApiResponse { Message = "Author not found" };

        if (!await _userManager.IsInRoleAsync(user, Roles.READER))
            return new ApiResponse { Message = "Error occurred" };

        var followings = await _unitOfWork.AuthorFollowingRepository
                    .GetAllAsync(x => x.ApplicationUserId == request.ReaderId, new[] { "Author" });

        var result = followings.Select(x => AuthorResponse.ConvertApplicationUserToUserResponse(x.Author));

        return new ApiResponse
        {
            Success = true,
            Data = result
        };
    }
}
