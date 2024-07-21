using GoodReadersClone.Infrastructure.DataAccess.Repositories;

namespace GoodReadersClone.Infrastructure.DataAccess.Abstractions;
public interface IUnitOfWork : IDisposable
{
    IAuthorRepository AuthorRepository { get; }
    IBookRepository BookRepository { get; }
    IGenreRepository GenreRepository { get; }
    IQuoteRepository QuoteRepository { get; }
    IAuthorFollowingRepository AuthorFollowingRepository { get; }
    IReviewRepository ReviewRepository { get; }
    IShelfItemRepository ShelfItemRepository { get; }
    IUsersRepository UsersRepository { get; }
    int Save();
}
