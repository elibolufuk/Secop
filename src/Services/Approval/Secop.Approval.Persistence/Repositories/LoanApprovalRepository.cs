using Secop.Approval.Persistence.DbContexts;
using Secop.Core.Application.Repositories.ApprovalRepositories;
using Secop.Core.Domain.Entities.ApprovalEntities;

namespace Secop.Approval.Persistence.Repositories
{
    public class LoanApprovalRepository : GenericRepository<LoanApproval>, ILoanApprovalRepository
    {
        public LoanApprovalRepository(ApprovalDbContext context) : base(context)
        {
        }
    }
}