using GoodReadsClone.Domain.Entities;
using GoodReadsClone.Infrastructure.DataAccess.Abstractions;

namespace GoodReadsClone.Infrastructure.DataAccess.Repositories;
public class AuthorFollowingRepository : Repository<AuthorFollowing>, IAuthorFollowingRepository
{
    public AuthorFollowingRepository(ApplicationDbContext _context) : base(_context)
    {
    }
}
