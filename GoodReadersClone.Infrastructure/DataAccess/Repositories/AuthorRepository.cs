using GoodReadersClone.Domain.Entities;
using GoodReadersClone.Infrastructure.DataAccess.Abstractions;
using GoodReadersClone.Infrastructure.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

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
}
