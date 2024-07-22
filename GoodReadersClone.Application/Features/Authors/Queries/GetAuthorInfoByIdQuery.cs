using GoodReadsClone.Application.DTOs;

namespace GoodReadsClone.Application.Features.Authors.Queries;
public record GetAuthorInfoByIdQuery(string AuthorId) : IRequest<ApiResponse>;
