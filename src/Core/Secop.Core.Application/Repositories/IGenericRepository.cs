using Secop.Core.Application.Results;
using Secop.Core.Domain.Entities;
using System.Linq.Expressions;

namespace Secop.Core.Application.Repositories
{
    public interface IGenericRepository<TEntity>
        where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(Guid id);
        Task<TEntity> FindByIdAsync(Guid id);
        Task AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(Guid id);
        Task SoftDeleteAsync(Guid id);

        Task<DataActionResult> SaveAsync();

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
    }
}