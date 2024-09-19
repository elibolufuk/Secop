using Microsoft.EntityFrameworkCore;
using Secop.Core.Application.Repositories;
using Secop.Core.Domain.Entities;

namespace Secop.Credit.Persistence.Repositories
{
    public class GenericRepository<TEntity>(DbContext context) : AbstractGenericRepository<TEntity>(context)
        where TEntity : BaseEntity
    {
        
    }
}
