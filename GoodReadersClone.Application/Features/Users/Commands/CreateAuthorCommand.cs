namespace GoodReadersClone.Application.Features.Users.Commands;
public record CreateAuthorCommand(UserRegisterRequest Request) : IRequest<UserModel>;
