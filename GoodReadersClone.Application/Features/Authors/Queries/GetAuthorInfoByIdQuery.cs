using GoodReadersClone.Application.DTOs.Author;

namespace GoodReadersClone.Application.Features.Authors.Queries;
public record GetAuthorInfoByIdQuery(AuthorInfoRequest InfoRequest) : IRequest<ApiResponse>; 
