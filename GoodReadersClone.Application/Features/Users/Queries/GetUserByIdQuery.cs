namespace GoodReadsClone.Application.Features.Users.Queries;
public record GetUserByIdQuery(string UserId) : IRequest<ApiResponse>;
