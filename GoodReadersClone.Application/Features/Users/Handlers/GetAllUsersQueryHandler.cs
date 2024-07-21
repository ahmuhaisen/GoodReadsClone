using GoodReadersClone.Application.Features.Users.Queries;
using GoodReadersClone.Domain.Models;

namespace GoodReadersClone.Application.Features.Users.Handlers;
public class GetAllReadersQueryHandler(UserManager<ApplicationUser> _userManager, IUnitOfWork _unitOfWork, IMapper _mapper)
    : IRequestHandler<GetAllUsersQuery, ApiResponse>
{
    public async Task<ApiResponse> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var allUsers = await _unitOfWork.UsersRepository
            .GetAllAsync(request.SearchTerm, request.PageIndex, request.PageSize);

        var result = _mapper.Map<PaginatedList<UserResponse>>(allUsers);

        return new ApiResponse
        {
            Success = true,
            Data = result
        };
    }
}

