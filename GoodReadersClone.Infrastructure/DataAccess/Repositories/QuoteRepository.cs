using GoodReadersClone.Domain.Entities;
using GoodReadersClone.Infrastructure.DataAccess.Abstractions;

namespace GoodReadersClone.Infrastructure.DataAccess.Repositories;
public class QuoteRepository : Repository<Quote>, IQuoteRepository
{
    public QuoteRepository(ApplicationDbContext _context) : base(_context)
    {
    }
}
