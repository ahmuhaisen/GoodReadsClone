using GoodReadsClone.Application.DTOs;
using GoodReadsClone.Application.DTOs.User;

namespace GoodReadsClone.Application.Features.Users.Commands;
public record CreateAuthorCommand(UserRegisterRequest Request) : IRequest<ApiResponse>;
