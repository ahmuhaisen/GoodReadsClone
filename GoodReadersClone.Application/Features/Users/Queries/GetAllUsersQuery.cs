namespace GoodReadersClone.Application.Features.Users.Queries;
public record GetAllUsersQuery() : IRequest<IEnumerable<UserInfoModel>>;
public record GetAllAuthorsQuery() : IRequest<IEnumerable<UserInfoModel>>;
