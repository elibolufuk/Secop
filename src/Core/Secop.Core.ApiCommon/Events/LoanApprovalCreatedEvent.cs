using Secop.Core.Domain.Enums;

namespace Secop.Core.ApiCommon.Events
{
    public class LoanApprovalCreatedEvent
    {
        public Guid CreditApplicationId { get; set; }
        public CreditRiskLevelType RiskLevel { get; set; }
        public ApplicationStatusType ApplicationStatus { get; set; }
        public string? Comment { get; set; }
    }
}
