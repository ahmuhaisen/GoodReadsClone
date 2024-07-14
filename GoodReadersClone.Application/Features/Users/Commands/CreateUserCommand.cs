using GoodReadersClone.Application.DTOs;
using MediatR;

namespace GoodReadersClone.Application.Features.Users.Commands;


public record CreateUserCommand(UserRegisterRequest Request) : IRequest<UsersModel>;