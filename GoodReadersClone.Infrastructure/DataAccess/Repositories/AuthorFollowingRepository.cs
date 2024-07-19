using GoodReadersClone.Domain.Entities;
using GoodReadersClone.Infrastructure.DataAccess.Abstractions;

namespace GoodReadersClone.Infrastructure.DataAccess.Repositories;
public class AuthorFollowingRepository : Repository<AuthorFollowing>, IAuthorFollowingRepository
{
    public AuthorFollowingRepository(ApplicationDbContext _context) : base(_context)
    {
    }
}
