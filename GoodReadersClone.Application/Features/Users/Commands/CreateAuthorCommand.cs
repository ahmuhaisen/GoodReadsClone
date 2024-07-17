using GoodReadersClone.Application.DTOs.User;

namespace GoodReadersClone.Application.Features.Users.Commands;
public record CreateAuthorCommand(UserRegisterRequest Request) : IRequest<ApiResponse>;
