using Secop.Core.Domain.Enums;

namespace Secop.Core.Domain.Entities.ScoreEntities
{
    public class CreditScore : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public int Score { get; set; }
        public DateTime ScoreDate { get; set; }
        public CreditRiskLevelType RiskLevel { get; set; }
    }
}