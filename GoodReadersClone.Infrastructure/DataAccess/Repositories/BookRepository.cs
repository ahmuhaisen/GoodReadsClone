using GoodReadersClone.Domain.Entities;
using GoodReadersClone.Domain.Models;
using GoodReadersClone.Infrastructure.DataAccess.Abstractions;
using GoodReadersClone.Infrastructure.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace GoodReadersClone.Infrastructure.DataAccess.Repositories;

public class BookRepository : Repository<Book>, IBookRepository
{
    private readonly ApplicationDbContext _context;

    public BookRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<int> Count()
    {
        return await _context.Books.CountAsync();
    }

    public async Task<PaginatedList<Book>> GetAllAsync(int pageIndex, int pageSize)
    {
        var count = await _context.Set<Book>().CountAsync();
        var totalPages = (int)Math.Ceiling(count / (double)pageSize);

        if (pageIndex <= 0)
            pageIndex = 1;

        if (pageIndex > totalPages)
            pageIndex = 1;

        if (pageSize <= 0 || pageSize > 20)
            pageSize = 20;

        IQueryable<Book> items = _context.Set<Book>()
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .Include(b => b.Author)
            .Include(b => b.Genres);

        return new PaginatedList<Book>(await items.ToListAsync(), pageIndex, totalPages);
    }
}
