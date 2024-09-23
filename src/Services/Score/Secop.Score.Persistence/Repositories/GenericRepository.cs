using Microsoft.EntityFrameworkCore;
using Secop.Core.Application.Repositories;
using Secop.Core.Domain.Entities;

namespace Secop.Score.Persistence.Repositories
{
    public class GenericRepository<TEntity>(DbContext context) : AbstractGenericRepository<TEntity>(context)
        where TEntity : BaseEntity
    {

    }
}
