using Microsoft.EntityFrameworkCore;
using Secop.Core.Application.Repositories;
using Secop.Core.Application.Results;
using Secop.Core.Domain.Entities;
using System.Linq.Expressions;

namespace Secop.Credit.Persistence.Repositories
{
    public class PostgreGenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly DbContext _context;

        public PostgreGenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            if (entity?.CreatedAt == DateTime.MinValue)
                entity.CreatedAt = DateTime.UtcNow;

            await _dbSet.AddAsync(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public async Task DeleteAsync(int id)
        {
            TEntity entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<DataActionResult> SaveAsync()
        {
            return new()
            {
                Success = true,
                RowsAffected = await _context.SaveChangesAsync()
            };
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Attach(entity);
        }
    }
}
