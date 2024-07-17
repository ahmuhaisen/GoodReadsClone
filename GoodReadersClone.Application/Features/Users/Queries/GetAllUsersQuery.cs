using GoodReadersClone.Application.DTOs.User;

namespace GoodReadersClone.Application.Features.Users.Queries;
public record GetAllUsersQuery() : IRequest<ApiResponse>;
