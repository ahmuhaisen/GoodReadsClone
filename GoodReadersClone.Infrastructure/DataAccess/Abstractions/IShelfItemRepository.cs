using GoodReadersClone.Domain.Entities;

namespace GoodReadersClone.Infrastructure.DataAccess.Abstractions;

public interface IShelfItemRepository : IRepository<ShelfItem>
{
    Task<IEnumerable<ShelfItemModel>> GetShelfItemsAsync(string ReaderId);
}
