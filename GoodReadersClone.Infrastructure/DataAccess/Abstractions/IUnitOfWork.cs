namespace GoodReadersClone.Infrastructure.DataAccess.Abstractions;
public interface IUnitOfWork : IDisposable
{
    int Save();
}
