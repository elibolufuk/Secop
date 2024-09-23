using Secop.Core.Domain.Enums;

namespace Secop.Core.ApiCommon.Events.V1
{
    public class CreditScoreCreatedEvent : CreditApplicationCreatedEvent
    {
        public int Score { get; set; }
        public CreditRiskLevelType RiskLevel { get; set; }
    }
}