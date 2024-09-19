using MediatR;
using Secop.Core.Application.Attributes;
using Secop.Core.Application.Constants;
using Secop.Core.Application.Repositories.CreditRepositories;
using Secop.Core.Application.Results;

namespace Secop.Core.Application.Features.Credit.CreditApplications.Commands.SoftDelete
{
    [ServiceHandler(ServiceHandlerType.Credit)]
    public class SoftDeleteCreditApplicationCommandHandler(ICreditApplicationRepository creditApplicationRepository)
        : IRequestHandler<SoftDeleteCreditApplicationCommand, BaseResponseResult>
    {
        private readonly ICreditApplicationRepository _creditApplicationRepository = creditApplicationRepository;

        public async Task<BaseResponseResult> Handle(SoftDeleteCreditApplicationCommand request, CancellationToken cancellationToken)
        {
            await _creditApplicationRepository.SoftDeleteAsync(request.Id);
            var result = await _creditApplicationRepository.SaveAsync();
            return new()
            {
                Succeeded = result.RowsAffected > 0
            };
        }
    }
}