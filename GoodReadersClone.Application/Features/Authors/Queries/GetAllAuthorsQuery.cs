using GoodReadsClone.Application.DTOs;

namespace GoodReadsClone.Application.Features.Authors.Queries;
public record GetAllAuthorsQuery() : IRequest<ApiResponse>;
public record GetAuthorBooksQuery(string AuthorId) : IRequest<ApiResponse>;
