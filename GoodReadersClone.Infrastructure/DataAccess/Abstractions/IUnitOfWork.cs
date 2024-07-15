namespace GoodReadersClone.Infrastructure.DataAccess.Abstractions;
public interface IUnitOfWork : IDisposable
{
    IAuthorRepository AuthorRepository { get; }
    int Save();
}
