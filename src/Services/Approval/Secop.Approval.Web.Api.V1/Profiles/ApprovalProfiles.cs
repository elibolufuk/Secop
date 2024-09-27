using AutoMapper;
using Secop.Core.Messaging.Events.V1;
using Secop.Core.Application.Features.Approval.LoanApprovals.Commands.Create;

namespace Secop.Approval.Web.Api.V1.Profiles
{
    public class ApprovalProfiles : Profile
    {
        public ApprovalProfiles()
        {
            CreateMap<CreditScoreCreatedEvent, CreateLoanApprovalCommand>();
            CreateMap<CreateLoanApprovalCommandResponse, LoanApprovalCreatedEvent>();
        }
    }
}
