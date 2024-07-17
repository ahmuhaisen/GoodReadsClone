﻿using GoodReadersClone.Application.Features.AuthorFollowings.Commands;
using GoodReadersClone.Infrastructure.DataAccess.Abstractions;

namespace GoodReadersClone.Application.Features.AuthorFollowings.Handlers;

public class DeleteFollowingCommandHandler(
    IUnitOfWork _unitOfWork,
    UserManager<ApplicationUser> _userManager)
    : IRequestHandler<DeleteFollowingCommand, ApiResponse>
{
    public async Task<ApiResponse> Handle(DeleteFollowingCommand request, CancellationToken cancellationToken)
    {
        var followingToDelete = await _unitOfWork.AuthorFollowingRepository
            .GetAsync(x => x.AuthorId == request.Request.AuthorId && x.ApplicationUserId == request.Request.ReaderId);
        
        if (followingToDelete is null)
            return new ApiResponse { Message = "Following not found" };

        _unitOfWork.AuthorFollowingRepository.Delete(followingToDelete);
        var result = _unitOfWork.Save();

        return new ApiResponse
        {
            Success = result != 0,
        };
    }
}

