using GoodReadsClone.Domain.Entities;
using GoodReadsClone.Infrastructure.DataAccess.Abstractions;

namespace GoodReadsClone.Infrastructure.DataAccess.Repositories;

public class GenreRepository : Repository<Genre>, IGenreRepository
{
    public GenreRepository(ApplicationDbContext _context) : base(_context)
    {
    }
}
