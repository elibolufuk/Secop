using AutoMapper;
using MediatR;
using Secop.Core.Application.Attributes;
using Secop.Core.Application.Constants;
using Secop.Core.Application.Repositories.CreditRepositories;
using Secop.Core.Application.Results;
using Secop.Core.Domain.Entities.CreditEntities;
using Secop.Core.Domain.Enums;

namespace Secop.Core.Application.Features.Credit.CreditApplications.Commands.Create
{
    [ServiceHandler(ServiceHandlerType.Credit)]
    public class CreateCreditApplicationCommandHandler(IMapper mapper, ICreditApplicationRepository creditApplicationRepository)
        : IRequestHandler<CreateCreditApplicationCommand, ResponseResult<CreateCreditApplicationCommandResponse>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly ICreditApplicationRepository _creditApplicationRepository = creditApplicationRepository;

        public async Task<ResponseResult<CreateCreditApplicationCommandResponse>> Handle(CreateCreditApplicationCommand request, CancellationToken cancellationToken)
        {
            var creditApplication = _mapper.Map<CreditApplication>(request);

            creditApplication.Id = Guid.NewGuid();
            creditApplication.ApplicationDate = DateTime.UtcNow;
            creditApplication.CreatedById = Guid.Empty;
            creditApplication.ApplicationStatus = ApplicationStatusType.ApplicationReceived;

            await _creditApplicationRepository.AddAsync(creditApplication);
            var result = await _creditApplicationRepository.SaveAsync();

            if (result.Success)
                return new()
                {
                    Succeeded = true,
                    Data = new() { Id = creditApplication.Id }
                };

            return new()
            {
                Succeeded = false
            };
        }
    }
}