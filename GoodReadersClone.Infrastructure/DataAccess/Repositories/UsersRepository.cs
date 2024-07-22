using GoodReadsClone.Domain.Entities;
using GoodReadsClone.Domain.Models;
using GoodReadsClone.Infrastructure.DataAccess.Abstractions;

namespace GoodReadsClone.Infrastructure.DataAccess.Repositories;

public class UsersRepository : Repository<ApplicationUser>, IUsersRepository
{
    private readonly ApplicationDbContext _context;

    public UsersRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<PaginatedList<ApplicationUser>> GetAllAsync(string searchTerm, int pageIndex, int pageSize)
    {
        IQueryable<ApplicationUser> usersQuery = _context.Users;

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            usersQuery = usersQuery.Where(u =>
            u.UserName!.Contains(searchTerm) ||
            u.FirstName!.Contains(searchTerm) ||
            u.LastName!.Contains(searchTerm));
        }

        return await PaginatedList<ApplicationUser>.CreateAsync(usersQuery, pageIndex, pageSize);
    }
}
