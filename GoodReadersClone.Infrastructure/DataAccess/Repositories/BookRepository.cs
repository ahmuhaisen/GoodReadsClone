using GoodReadersClone.Domain.Entities;
using GoodReadersClone.Domain.Models;
using GoodReadersClone.Infrastructure.DataAccess.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace GoodReadersClone.Infrastructure.DataAccess.Repositories;

public class BookRepository : Repository<Book>, IBookRepository
{
    private readonly ApplicationDbContext _context;

    public BookRepository(ApplicationDbContext context) : base(context) => _context = context;
    

    public new async Task<PaginatedList<Book>> GetAllAsync(string searchTerm, int pageIndex, int pageSize)
    {
        IQueryable<Book> booksQuery = _context.Books
            .Include(b => b.Author);

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            booksQuery = booksQuery.Where(b => b.Title!.Contains(searchTerm));
        }

        return await PaginatedList<Book>.CreateAsync(booksQuery, pageIndex, pageSize);
    }
}
