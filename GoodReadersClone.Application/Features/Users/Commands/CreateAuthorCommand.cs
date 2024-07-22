namespace GoodReadsClone.Application.Features.Users.Commands;
public record CreateAuthorCommand(UserRegisterRequest Request) : IRequest<ApiResponse>;
