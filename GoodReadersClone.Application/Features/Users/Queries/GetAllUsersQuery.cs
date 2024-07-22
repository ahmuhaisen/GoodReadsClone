using GoodReadsClone.Application.DTOs;

namespace GoodReadsClone.Application.Features.Users.Queries;
public record GetAllUsersQuery(string? SearchTerm, int PageIndex, int PageSize) : IRequest<ApiResponse>;
