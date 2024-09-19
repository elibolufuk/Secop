using MediatR;
using Secop.Core.Domain.Enums;

namespace Secop.Core.Application.Features.Credit.CreditApplications.Commands.Update
{
    public class UpdateCreditApplicationCommand : IRequest<UpdateCreditApplicationCommandResponse>
    {
        public Guid Id { get; set; }
        public CreditRiskLevelType? RiskLevel { get; set; }
        public ApplicationStatusType? ApplicationStatus { get; set; }
        public string? Comment { get; set; }
    }
}
