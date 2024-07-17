namespace GoodReadersClone.Application.Features.AuthorFollowings.Queries;
public record GetAuthorFollowersQuery(string AuthorId) : IRequest<ApiResponse>;

