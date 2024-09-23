using Secop.Core.Application.Repositories.ScoreRepositories;
using Secop.Core.Domain.Entities.ScoreEntities;
using Secop.Score.Persistence.DbContexts;

namespace Secop.Score.Persistence.Repositories
{
    public class RiskLevelRangeRepository(ScoreDbContext context)
        : GenericRepository<RiskLevelRange>(context), IRiskLevelRangeRepository
    {
    }
}