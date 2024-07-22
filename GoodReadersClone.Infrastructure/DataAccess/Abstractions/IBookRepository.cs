using GoodReadsClone.Domain.Entities;
using GoodReadsClone.Domain.Models;

namespace GoodReadsClone.Infrastructure.DataAccess.Abstractions;
public interface IBookRepository : IRepository<Book>
{
    Task<PaginatedList<Book>> GetAllAsync(string searchTerm, int pageIndex, int pageSize);

}

public interface IGenreRepository : IRepository<Genre>
{
}
