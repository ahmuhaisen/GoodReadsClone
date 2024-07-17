namespace GoodReadersClone.Infrastructure.DataAccess.Abstractions;
public interface IUnitOfWork : IDisposable
{
    IAuthorRepository AuthorRepository { get; }
    IBookRepository BookRepository { get; }
    IQuoteRepository QuoteRepository { get; }
    IAuthorFollowingRepository AuthorFollowingRepository { get; }
    int Save();
}
