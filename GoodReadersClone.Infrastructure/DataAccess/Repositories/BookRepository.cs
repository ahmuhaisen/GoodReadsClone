using GoodReadsClone.Domain.Entities;
using GoodReadsClone.Domain.Models;
using GoodReadsClone.Infrastructure.DataAccess.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace GoodReadsClone.Infrastructure.DataAccess.Repositories;

public class BookRepository : Repository<Book>, IBookRepository
{
    private readonly ApplicationDbContext _context;

    public BookRepository(ApplicationDbContext context) : base(context) => _context = context;


    public new async Task<PaginatedList<Book>> GetAllAsync(string searchTerm, int pageIndex, int pageSize)
    {
        IQueryable<Book> booksQuery = _context.Books
            .OrderBy(b => b.Title)
            .Include(b => b.Author)
            .Include(b => b.Genres);

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            booksQuery = booksQuery.Where(b => b.Title!.Contains(searchTerm));
        }

        return await PaginatedList<Book>.CreateAsync(booksQuery, pageIndex, pageSize);
    }
}
