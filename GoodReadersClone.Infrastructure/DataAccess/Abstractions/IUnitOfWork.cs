namespace GoodReadersClone.Infrastructure.DataAccess.Abstractions;
public interface IUnitOfWork : IDisposable
{
    IAuthorRepository AuthorRepository { get; }
    IBookRepository BookRepository { get; }
    IQuoteRepository QuoteRepository { get; }
    int Save();
}
