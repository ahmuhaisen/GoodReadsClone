using GoodReadersClone.Domain.Entities;
using System.Linq.Expressions;

namespace GoodReadersClone.Infrastructure.DataAccess.Abstractions;
public interface IAuthorRepository : IRepository<Author>
{
    Task<Author?> GetAsync(string id);
   bool IsExist(Expression<Func<Author, bool>> condition);
}
