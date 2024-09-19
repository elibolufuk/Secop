using Secop.Core.Domain.Enums;

namespace Secop.Core.Application.Features.Score.CreditScores.Commands.Create
{
    public class CreateCreditScoreCommandResponse
    {
        public Guid Id { get; set; }
        public int Score { get; set; }
        public CreditRiskLevelType RiskLevel { get; set; }
    }
}
