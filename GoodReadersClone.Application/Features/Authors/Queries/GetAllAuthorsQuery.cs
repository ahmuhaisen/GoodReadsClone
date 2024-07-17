using GoodReadersClone.Application.DTOs.User;

namespace GoodReadersClone.Application.Features.Authors.Queries;
public record GetAllAuthorsQuery() : IRequest<ApiResponse>;
public record GetAuthorBooksQuery(string AuthorId) : IRequest<ApiResponse>;
