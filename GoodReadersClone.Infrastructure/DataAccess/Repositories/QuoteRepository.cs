using GoodReadersClone.Domain.Entities;
using GoodReadersClone.Infrastructure.DataAccess.Abstractions;
using GoodReadersClone.Infrastructure.DataAccess.Data;

namespace GoodReadersClone.Infrastructure.DataAccess.Repositories;
internal class QuoteRepository : Repository<Quote>, IQuoteRepository
{
    public QuoteRepository(ApplicationDbContext _context) : base(_context)
    {
    }
}
