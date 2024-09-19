using Secop.Core.Domain.Enums;

namespace Secop.Core.ApiCommon.Events
{
    public class CreditScoreCreatedEvent : CreditApplicationCreatedEvent
    {
        public int Score { get; set; }
        public CreditRiskLevelType RiskLevel { get; set; }
    }
}