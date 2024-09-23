using Secop.Core.Application.Repositories.CreditRepositories;
using Secop.Core.Domain.Entities.CreditEntities;
using Secop.Credit.Persistence.DbContexts;

namespace Secop.Credit.Persistence.Repositories
{
    public class CreditApplicationRepository(CreditDbContext context) : GenericRepository<CreditApplication>(context), ICreditApplicationRepository
    {
    }
}