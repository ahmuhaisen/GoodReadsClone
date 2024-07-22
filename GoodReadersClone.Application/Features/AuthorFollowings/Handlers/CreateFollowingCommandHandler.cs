using GoodReadsClone.Application.Features.AuthorFollowings.Commands;

namespace GoodReadsClone.Application.Features.AuthorFollowings.Handlers;

public class CreateFollowingCommandHandler(
    IUnitOfWork _unitOfWork,
    UserManager<ApplicationUser> _userManager)
    : IRequestHandler<CreateFollowingCommand, ApiResponse>
{
    public async Task<ApiResponse> Handle(CreateFollowingCommand request, CancellationToken cancellationToken)
    {
        if (!_unitOfWork.AuthorRepository.IsExist(x => x.Id == request.Request.AuthorId))
            return new ApiResponse { Message = "Author not found" };

        var user = await _userManager.FindByIdAsync(request.Request.ReaderId!);

        if (user is null)
            return new ApiResponse { Message = "Reader not found" };

        if (!await _userManager.IsInRoleAsync(user, Roles.READER))
            return new ApiResponse { Message = "Error occurred" };


        var authorFollowing = new AuthorFollowing
        {
            ApplicationUserId = request.Request.ReaderId!,
            AuthorId = request.Request.AuthorId
        };

        if (await _unitOfWork.AuthorFollowingRepository.IsExist(x => x.AuthorId == request.Request.AuthorId && x.ApplicationUserId == request.Request.ReaderId))
            return new ApiResponse { Message = "The Reader is already follow this Author" };

        _unitOfWork.AuthorFollowingRepository.Create(authorFollowing);
        var result = _unitOfWork.Save();

        return new ApiResponse
        {
            Success = result != 0,
        };
    }
}


