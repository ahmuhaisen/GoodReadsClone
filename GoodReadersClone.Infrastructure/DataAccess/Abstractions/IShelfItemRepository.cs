using GoodReadsClone.Domain.Entities;

namespace GoodReadsClone.Infrastructure.DataAccess.Abstractions;

public interface IShelfItemRepository : IRepository<ShelfItem>
{
    Task<IEnumerable<ShelfItemModel>> GetShelfItemsAsync(string ReaderId);
}
