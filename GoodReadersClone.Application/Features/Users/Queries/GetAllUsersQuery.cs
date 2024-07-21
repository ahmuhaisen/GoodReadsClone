namespace GoodReadersClone.Application.Features.Users.Queries;
public record GetAllUsersQuery(string? SearchTerm, int PageIndex, int PageSize) : IRequest<ApiResponse>;
