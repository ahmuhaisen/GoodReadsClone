using GoodReadersClone.Application.DTOs.User;

namespace GoodReadersClone.Application.Features.Users.Commands;


public record CreateReaderCommand(UserRegisterRequest Request) : IRequest<UserModel>;

