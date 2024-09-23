using Secop.Approval.Persistence.DbContexts;
using Secop.Core.Application.Repositories.ApprovalRepositories;
using Secop.Core.Domain.Entities.ApprovalEntities;

namespace Secop.Approval.Persistence.Repositories
{
    public class LoanApprovalRepository(ApprovalDbContext context) : GenericRepository<LoanApproval>(context), ILoanApprovalRepository
    {
    }
}