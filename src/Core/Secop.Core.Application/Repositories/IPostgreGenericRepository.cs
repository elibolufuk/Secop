using Secop.Core.Domain.Entities;
using System.Linq.Expressions;

namespace Secop.Core.Application.Repositories
{
    public interface IPostgreGenericRepository<T>
        where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);

        Task<DataActionResult> SaveAsync();

        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    }
}