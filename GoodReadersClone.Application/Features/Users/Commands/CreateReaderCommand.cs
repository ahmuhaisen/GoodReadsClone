namespace GoodReadsClone.Application.Features.Users.Commands;


public record CreateReaderCommand(UserRegisterRequest Request) : IRequest<ApiResponse>;

