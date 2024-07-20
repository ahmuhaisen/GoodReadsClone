using GoodReadersClone.Infrastructure.DataAccess.Abstractions;
using GoodReadersClone.Infrastructure.DataAccess.Repositories;

namespace GoodReadersClone.Infrastructure.DataAccess;
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public IAuthorRepository AuthorRepository { get; }
    public IBookRepository BookRepository { get; }
    public IGenreRepository GenreRepository { get; }
    public IQuoteRepository QuoteRepository { get; }
    public IAuthorFollowingRepository AuthorFollowingRepository { get; }
    public IReviewRepository ReviewRepository { get; }
    public IShelfItemRepository ShelfItemRepository { get; }


    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        AuthorRepository = new AuthorRepository(_context);
        BookRepository = new BookRepository(_context);
        QuoteRepository = new QuoteRepository(_context);
        AuthorFollowingRepository = new AuthorFollowingRepository(_context);
        GenreRepository = new GenreRepository(_context);
        ReviewRepository = new ReviewRepository(_context);
        ShelfItemRepository = new ShelfItemRepository(_context);
    }

    public int Save() => _context.SaveChanges();
    

    public void Dispose() =>  _context.Dispose();
    
}
