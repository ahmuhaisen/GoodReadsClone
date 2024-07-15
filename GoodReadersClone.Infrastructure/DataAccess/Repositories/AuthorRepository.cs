using GoodReadersClone.Domain.Entities;
using GoodReadersClone.Infrastructure.DataAccess.Abstractions;
using GoodReadersClone.Infrastructure.DataAccess.Data;

namespace GoodReadersClone.Infrastructure.DataAccess.Repositories;
public class AuthorRepository : Repository<Author>, IAuthorRepository
{
    public AuthorRepository(ApplicationDbContext _context) : base(_context)
    {
    }
}
