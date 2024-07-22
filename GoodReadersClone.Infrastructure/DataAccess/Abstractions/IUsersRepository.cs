using GoodReadsClone.Domain.Entities;
using GoodReadsClone.Domain.Models;

namespace GoodReadsClone.Infrastructure.DataAccess.Abstractions;
public interface IUsersRepository : IRepository<ApplicationUser>
{
    Task<PaginatedList<ApplicationUser>> GetAllAsync(string searchTerm, int pageIndex, int pageSize);
}
