using GoodReadersClone.Domain.Entities;
using GoodReadersClone.Infrastructure.DataAccess.Abstractions;
using GoodReadersClone.Infrastructure.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GoodReadersClone.Infrastructure.DataAccess.Repositories;
public class AuthorRepository : Repository<Author>, IAuthorRepository
{
    private readonly ApplicationDbContext _context;

    public AuthorRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Author?> GetAsync(string id)
    {
        return await _context.Authors
            .AsNoTracking()
            .Include(a => a.Books)
            .SingleOrDefaultAsync(a => a.Id == id);
    }

    public async Task<IEnumerable<AuthorFollowing>> GetAllFollowersAsync(string authorId)
    {
        var author = await _context.Authors
            .AsNoTracking()
            .Include(a => a.Followers)
            .SingleOrDefaultAsync(a => a.Id == authorId);

        return author!.Followers.ToList();
    }

    public bool IsExist(Expression<Func<Author, bool>> condition)
    {
        return _context.Authors.Any(condition);
    }
}
