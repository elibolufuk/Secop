using AutoMapper;
using MediatR;
using Secop.Core.Application.Attributes;
using Secop.Core.Application.Constants;
using Secop.Core.Application.Repositories.ApprovalRepositories;
using Secop.Core.Application.Results;
using Secop.Core.Domain.Entities.ApprovalEntities;
using Secop.Core.Domain.Enums;

namespace Secop.Core.Application.Features.Approval.LoanApprovals.Commands.Create
{
    [ServiceHandler(ServiceHandlerType.Approval)]
    public class CreateLoanApprovalCommandHandler(IMapper mapper, ILoanApprovalRepository loanApprovalRepository)
        : IRequestHandler<CreateLoanApprovalCommand, ResponseResult<CreateLoanApprovalCommandResponse>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly ILoanApprovalRepository _loanApprovalRepository = loanApprovalRepository;
        public async Task<ResponseResult<CreateLoanApprovalCommandResponse>> Handle(CreateLoanApprovalCommand request, CancellationToken cancellationToken)
        {
            var loanApproval = _mapper.Map<LoanApproval>(request);
            loanApproval.Id = Guid.NewGuid();
            loanApproval.CreatedById = Guid.Empty;
            loanApproval.ApplicationStatus = request.RiskLevel switch
            {
                CreditRiskLevelType.HighRisk or CreditRiskLevelType.VeryHighRisk => ApplicationStatusType.Rejected,
                _ => ApplicationStatusType.Approved
            };

            var commentStatusText = loanApproval.ApplicationStatus switch
            {
                ApplicationStatusType.Rejected => $" onaylanmadı. Kredi puan düşük : {loanApproval.Score}",
                _ => "onaylandı."
            };
            loanApproval.Comment = $"Kredi başvurusu {commentStatusText}.";

            await _loanApprovalRepository.Add(loanApproval);
            var result = await _loanApprovalRepository.SaveAsync();

            if (result.Success)
                return new()
                {
                    Succeeded = true,
                    Data = _mapper.Map<CreateLoanApprovalCommandResponse>(loanApproval)
                };

            return new()
            {
                Succeeded = false
            };
        }
    }
}