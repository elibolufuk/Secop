using Secop.Core.Application.Results;
using Secop.Core.Domain.Entities;
using System.Linq.Expressions;

namespace Secop.Core.Application.Repositories
{
    public interface IGenericRepository<TEntity>
        where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(int id);

        Task AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(int id);

        Task<DataActionResult> SaveAsync();

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
    }
}