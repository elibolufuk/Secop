using Secop.Core.Domain.Enums;

namespace Secop.Core.Application.Features.Approval.LoanApprovals.Commands.Create
{
    public class CreateLoanApprovalCommandResponse
    {
        public Guid Id { get; set; }
        public Guid CreditApplicationId { get; set; }
        public decimal Amount { get; set; }
        public int TermMonths { get; set; }
        public int Score { get; set; }
        public CreditRiskLevelType RiskLevel { get; set; }
        public ApplicationStatusType ApplicationStatus { get; set; }
        public string? Comment { get; set; }
    }
}
