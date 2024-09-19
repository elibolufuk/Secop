using AutoMapper;
using Secop.Core.ApiCommon.Events;
using Secop.Core.Application.Features.Approval.LoanApprovals.Commands.Create;

namespace Secop.Approval.Web.Api.Profiles
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
