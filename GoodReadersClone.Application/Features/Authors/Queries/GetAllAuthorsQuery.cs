using GoodReadersClone.Application.DTOs.User;

namespace GoodReadersClone.Application.Features.Authors.Queries;
public record GetAllAuthorsQuery() : IRequest<IEnumerable<UserInfoModel>>;
public record GetAuthorBooksQuery(string AuthorId) : IRequest<ApiResponse>;
