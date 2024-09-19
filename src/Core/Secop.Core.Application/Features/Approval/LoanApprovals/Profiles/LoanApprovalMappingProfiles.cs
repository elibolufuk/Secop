using AutoMapper;
using Secop.Core.Application.Features.Approval.LoanApprovals.Commands.Create;
using Secop.Core.Domain.Entities.ApprovalEntities;

namespace Secop.Core.Application.Features.Approval.LoanApprovals.Profiles
{
    public class LoanApprovalMappingProfiles : Profile
    {
        public LoanApprovalMappingProfiles()
        {
            CreateMap<CreateLoanApprovalCommand, LoanApproval>();
            CreateMap<LoanApproval, CreateLoanApprovalCommandResponse>();
        }
    }
}
