using GoodReadersClone.Domain.Entities;
using GoodReadersClone.Infrastructure.DataAccess.Abstractions;
using GoodReadersClone.Infrastructure.DataAccess.Data;

namespace GoodReadersClone.Infrastructure.DataAccess.Repositories;
public class ShelfItemRepository : Repository<ShelfItem>, IShelfItemRepository
{
    public ShelfItemRepository(ApplicationDbContext _context) : base(_context)
    {
    }
}
