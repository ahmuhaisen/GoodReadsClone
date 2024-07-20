using GoodReadersClone.Domain.Entities;
using System.Linq.Expressions;

namespace GoodReadersClone.Infrastructure.DataAccess.Abstractions;
public interface IAuthorRepository : IRepository<Author>
{
    Task<Author?> GetAsync(string id);
    Task<IEnumerable<AuthorFollowing>> GetAllFollowersAsync(string authorId);
    new bool IsExist(Expression<Func<Author, bool>> condition);
}
