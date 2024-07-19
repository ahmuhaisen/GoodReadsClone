using GoodReadersClone.Domain.Entities;
using GoodReadersClone.Infrastructure.DataAccess.Abstractions;

namespace GoodReadersClone.Infrastructure.DataAccess.Repositories;

public class GenreRepository : Repository<Genre>, IGenreRepository
{
    public GenreRepository(ApplicationDbContext _context) : base(_context)
    {
    }
}
