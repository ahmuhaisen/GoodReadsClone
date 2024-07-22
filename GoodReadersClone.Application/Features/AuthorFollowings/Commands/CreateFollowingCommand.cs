using GoodReadsClone.Application.DTOs.AuthorFollowing;

namespace GoodReadsClone.Application.Features.AuthorFollowings.Commands;
public record CreateFollowingCommand(FollowRequest Request) : IRequest<ApiResponse>;
public record DeleteFollowingCommand(FollowRequest Request) : IRequest<ApiResponse>;
