using GoodReadersClone.Domain.Entities;

namespace GoodReadersClone.Infrastructure.DataAccess.Abstractions;
public interface IBookRepository : IRepository<Book>
{
}

public interface IGenreRepository : IRepository<Genre>
{
}
