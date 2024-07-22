using GoodReadsClone.Domain.Entities;
using GoodReadsClone.Infrastructure.DataAccess.Abstractions;

namespace GoodReadsClone.Infrastructure.DataAccess.Repositories;
public class QuoteRepository : Repository<Quote>, IQuoteRepository
{
    public QuoteRepository(ApplicationDbContext _context) : base(_context)
    {
    }
}
