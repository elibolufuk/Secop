using Secop.Core.Application.Repositories.CreditRepositories;
using Secop.Core.Domain.Entities.CreditEntities;
using Secop.Credit.Persistence.DbContexts;

namespace Secop.Credit.Persistence.Repositories
{
    public class CreditApplicationRepository : GenericRepository<CreditApplication>, ICreditApplicationRepository
    {
        public CreditApplicationRepository(CreditDbContext context) : base(context)
        {
        }
    }
}