using GoodReadersClone.Application.DTOs.AuthorFollowing;

namespace GoodReadersClone.Application.Features.AuthorFollowings.Commands;
public record CreateFollowingCommand(FollowingRequest Request) : IRequest<ApiResponse>;
public record DeleteFollowingCommand(FollowingRequest Request) : IRequest<ApiResponse>;
