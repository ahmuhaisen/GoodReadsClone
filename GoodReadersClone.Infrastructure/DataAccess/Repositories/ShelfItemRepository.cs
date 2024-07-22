using GoodReadsClone.Domain.Entities;
using GoodReadsClone.Infrastructure.DataAccess.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace GoodReadsClone.Infrastructure.DataAccess.Repositories;
public class ShelfItemRepository : Repository<ShelfItem>, IShelfItemRepository
{
    private readonly ApplicationDbContext _context;

    public ShelfItemRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ShelfItemModel>> GetShelfItemsAsync(string ReaderId)
    {
        var result = await _context.GetShelfItems(ReaderId).ToListAsync();
        return result;
    }
}
