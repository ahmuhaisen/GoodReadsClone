namespace GoodReadersClone.Application.Features.Users.Commands;


public record SetUserAsAuthorCommand(string UserId) : IRequest<UserModel>;

