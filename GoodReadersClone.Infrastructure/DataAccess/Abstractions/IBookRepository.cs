using GoodReadersClone.Domain.Entities;
using GoodReadersClone.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GoodReadersClone.Infrastructure.DataAccess.Abstractions;
public interface IBookRepository : IRepository<Book>
{
    Task<PaginatedList<Book>> GetAllAsync(string searchTerm, int pageIndex, int pageSize);

}

public interface IGenreRepository : IRepository<Genre>
{
}
