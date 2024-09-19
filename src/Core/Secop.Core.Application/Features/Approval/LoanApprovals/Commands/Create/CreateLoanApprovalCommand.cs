using MediatR;
using Secop.Core.Application.Results;
using Secop.Core.Domain.Enums;

namespace Secop.Core.Application.Features.Approval.LoanApprovals.Commands.Create
{
    public class CreateLoanApprovalCommand : IRequest<ResponseResult<CreateLoanApprovalCommandResponse>>
    {
        public Guid CreditApplicationId { get; set; }
        public decimal Amount { get; set; }
        public int TermMonths { get; set; }
        public int Score { get; set; }
        public CreditRiskLevelType RiskLevel { get; set; }
    }
}
