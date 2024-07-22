using GoodReadsClone.Application.DTOs;
using GoodReadsClone.Application.DTOs.User;

namespace GoodReadsClone.Application.Features.Users.Commands;


public record CreateReaderCommand(UserRegisterRequest Request) : IRequest<ApiResponse>;

