using GoodReadersClone.Infrastructure.DataAccess.Abstractions;
using GoodReadersClone.Infrastructure.DataAccess.Data;
using GoodReadersClone.Infrastructure.DataAccess.Repositories;

namespace GoodReadersClone.Infrastructure.DataAccess;
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public IAuthorRepository AuthorRepository { get; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        AuthorRepository = new AuthorRepository(_context);
    }

    public int Save()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
