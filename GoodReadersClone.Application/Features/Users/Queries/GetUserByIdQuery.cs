namespace GoodReadersClone.Application.Features.Users.Queries;
public record GetUserByIdQuery(string UserId) : IRequest<UserInfoModel>;
