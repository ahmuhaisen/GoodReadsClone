using GoodReadersClone.Domain.Entities;
using GoodReadersClone.Domain.Models;

namespace GoodReadersClone.Infrastructure.DataAccess.Abstractions;

public interface IShelfItemRepository : IRepository<ShelfItem>
{
    Task<IEnumerable<ShelfItemModel>> GetShelfItemsAsync(string ReaderId);
}
