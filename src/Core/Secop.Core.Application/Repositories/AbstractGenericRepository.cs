using Microsoft.EntityFrameworkCore;
using Secop.Core.Application.Results;
using Secop.Core.Domain.Entities;
using Secop.Core.Domain.Enums;
using System.Linq.Expressions;

namespace Secop.Core.Application.Repositories
{
    public class AbstractGenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly DbSet<TEntity> DbSet;
        protected readonly DbContext Context;

        public AbstractGenericRepository(DbContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            if (entity == null)
                return;

            if (entity?.CreatedAt == DateTime.MinValue)
                entity.CreatedAt = DateTime.UtcNow;

            if (entity?.Id == Guid.Empty)
                entity.Id = Guid.NewGuid();

            await DbSet.AddAsync(entity);
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().AnyAsync(predicate);
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).AsNoTracking().FirstOrDefaultAsync();
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            TEntity entity = await GetByIdAsync(id);
            if (entity != null)
            {
                DbSet.Remove(entity);
            }
        }

        public virtual async Task SoftDeleteAsync(Guid id)
        {
            var entity = await FindByIdAsync(id);
            if (entity == null)
                return;

            entity.EntityStatus = EntityStatusType.Deleted;
            await UpdateAsync(entity);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<TEntity> FindByIdAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<DataActionResult> SaveAsync()
        {
            try
            {
                return new()
                {
                    Success = true,
                    RowsAffected = await Context.SaveChangesAsync()
                };
            }
            catch (Exception ex)
            {
                return new()
                {
                    ExceptionMessage = ex.Message,
                    RowsAffected = 0,
                    Success = false
                };
            }
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            if (entity?.UpdatedAt == DateTime.MinValue)
                entity.UpdatedAt = DateTime.UtcNow;

            DbSet.Attach(entity);
        }

        public virtual IQueryable<TEntity> GetQueryable()
        {
            return DbSet.AsNoTracking().AsQueryable();
        }
    }
}
