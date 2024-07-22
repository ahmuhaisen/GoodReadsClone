using GoodReadsClone.Domain.Entities;
using GoodReadsClone.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReadsClone.Infrastructure.DataAccess.Abstractions;
public interface IUsersRepository : IRepository<ApplicationUser>
{
    Task<PaginatedList<ApplicationUser>> GetAllAsync(string searchTerm, int pageIndex, int pageSize);
}
