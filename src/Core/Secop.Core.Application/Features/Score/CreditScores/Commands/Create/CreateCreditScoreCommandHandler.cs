using AutoMapper;
using MediatR;
using Secop.Core.Application.Attributes;
using Secop.Core.Application.Constants;
using Secop.Core.Application.Features.Score.RiskLevelRange.Queries.GetRiskLevelByScore;
using Secop.Core.Application.Repositories.ScoreRepositories;
using Secop.Core.Application.Results;
using Secop.Core.Domain.Entities.ScoreEntities;

namespace Secop.Core.Application.Features.Score.CreditScores.Commands.Create
{
    [ServiceHandler(ServiceHandlerType.Score)]
    internal class CreateCreditScoreCommandHandler(ICreditScoreRepository creditScoreRepository, IMapper mapper, IMediator mediator)
        : IRequestHandler<CreateCreditScoreCommand, ResponseResult<CreateCreditScoreCommandResponse>>
    {
        private readonly ICreditScoreRepository _creditScoreRepository = creditScoreRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IMediator _mediator = mediator;

        public async Task<ResponseResult<CreateCreditScoreCommandResponse>> Handle(CreateCreditScoreCommand request, CancellationToken cancellationToken)
        {
            var creditScore = _mapper.Map<CreditScore>(request);
            creditScore.Id = Guid.NewGuid();
            creditScore.ScoreDate = DateTime.UtcNow;
            creditScore.Score = new Random().Next(1000, 1999);

            var score = await _mediator.Send(new GetRiskLevelByScoreQuery() { Score = creditScore.Score }, cancellationToken);
            if (!score.Succeeded)
                return new() { Data = new(), Succeeded = false };

            creditScore.RiskLevel = score.Data.RiskLevel;

            await _creditScoreRepository.Add(creditScore);
            var result = await _creditScoreRepository.SaveAsync();

            if (!result.Success)
                return new() { Data = new(), Succeeded = false };

            var responseData = _mapper.Map<CreateCreditScoreCommandResponse>(creditScore);
            return new()
            {
                Data = responseData,
                Succeeded = true
            };
        }
    }
}
