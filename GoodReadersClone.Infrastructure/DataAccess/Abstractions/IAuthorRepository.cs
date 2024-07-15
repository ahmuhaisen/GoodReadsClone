using GoodReadersClone.Domain.Entities;

namespace GoodReadersClone.Infrastructure.DataAccess.Abstractions;
public interface IAuthorRepository : IRepository<Author>
{
    Task<Author?> GetAsync(string id);
}
