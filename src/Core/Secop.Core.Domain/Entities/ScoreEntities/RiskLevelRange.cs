using Secop.Core.Domain.Enums;

namespace Secop.Core.Domain.Entities.ScoreEntities
{
    public class RiskLevelRange : BaseEntity
    {
        public CreditRiskLevelType RiskLevel { get; set; }
        public int MinScore { get; set; }
        public int MaxScore { get; set; }
    }
}
