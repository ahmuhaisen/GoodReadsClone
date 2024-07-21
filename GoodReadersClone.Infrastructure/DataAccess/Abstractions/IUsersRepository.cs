using GoodReadersClone.Domain.Entities;
using GoodReadersClone.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReadersClone.Infrastructure.DataAccess.Abstractions;
public interface IUsersRepository : IRepository<ApplicationUser>
{
    Task<PaginatedList<ApplicationUser>> GetAllAsync(string searchTerm, int pageIndex, int pageSize);
}
