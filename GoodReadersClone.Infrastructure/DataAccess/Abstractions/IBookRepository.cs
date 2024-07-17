using GoodReadersClone.Domain.Entities;

namespace GoodReadersClone.Infrastructure.DataAccess.Abstractions;
public interface IBookRepository : IRepository<Book>
{
    Task<int> Count();
}

public interface IGenreRepository : IRepository<Genre>
{
}
