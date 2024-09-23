using MediatR;
using Secop.Core.Application.Attributes;
using Secop.Core.Application.Constants;
using Secop.Core.Application.Repositories.CreditRepositories;

namespace Secop.Core.Application.Features.Credit.CreditApplications.Commands.Update
{
    [ServiceHandler(ServiceHandlerType.Credit)]
    internal class UpdateCreditApplicationCommandHandler(ICreditApplicationRepository creditApplicationRepository)
        : IRequestHandler<UpdateCreditApplicationCommand, UpdateCreditApplicationCommandResponse>
    {
        private readonly ICreditApplicationRepository _creditApplicationRepository = creditApplicationRepository;
        public async Task<UpdateCreditApplicationCommandResponse> Handle(UpdateCreditApplicationCommand request, CancellationToken cancellationToken)
        {
            var creditApplication = await _creditApplicationRepository.FindByIdAsync(request.Id);

            if (creditApplication == null)
                return new() { Succeeded = false };

            if (request.RiskLevel.HasValue)
                creditApplication.RiskLevelType = request.RiskLevel.Value;
            if (request.ApplicationStatus.HasValue)
                creditApplication.ApplicationStatus = request.ApplicationStatus.Value;
            if (request.Comment != null)
                creditApplication.Comment = request.Comment;

            await _creditApplicationRepository.UpdateAsync(creditApplication);
            var result = await _creditApplicationRepository.SaveAsync();

            return new() { Succeeded = result.Success && result.RowsAffected > 0 };
        }
    }
}
