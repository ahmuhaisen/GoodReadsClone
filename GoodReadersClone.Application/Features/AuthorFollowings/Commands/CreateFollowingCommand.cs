using GoodReadersClone.Application.DTOs.AuthorFollowing;

namespace GoodReadersClone.Application.Features.AuthorFollowings.Commands;
public record CreateFollowingCommand(FollowRequest Request) : IRequest<ApiResponse>;
public record DeleteFollowingCommand(FollowRequest Request) : IRequest<ApiResponse>;
