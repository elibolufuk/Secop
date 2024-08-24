#pragma warning disable CS8618
using Secop.Core.Domain.Enums;

namespace Secop.Core.Domain.Entities.ApprovalEntities
{
    public class LoanApproval : BaseEntity
    {
        public int CreditApplicationId { get; set; }
        public decimal Amount { get; set; }
        public int TermMonths { get; set; }
        public int Score { get; set; }
        public CreditRiskLevelType RiskLevel { get; set; }
        public ApplicationStatusType ApplicationStatus { get; set; }
        public string Comments { get; set; }
    }
}