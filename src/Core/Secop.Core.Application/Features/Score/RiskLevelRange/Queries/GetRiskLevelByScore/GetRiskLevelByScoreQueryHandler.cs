using MediatR;
using Secop.Core.Application.Attributes;
using Secop.Core.Application.Constants;
using Secop.Core.Application.Repositories.ScoreRepositories;
using Secop.Core.Application.Results;

namespace Secop.Core.Application.Features.Score.RiskLevelRange.Queries.GetRiskLevelByScore
{
    [ServiceHandler(ServiceHandlerType.Score)]
    internal class GetRiskLevelByScoreQueryHandler(IRiskLevelRangeRepository riskLevelRangeRepopsitory) : IRequestHandler<GetRiskLevelByScoreQuery, ResponseResult<GetRiskLevelByScoreQueryResponse>>
    {
        private readonly IRiskLevelRangeRepository _riskLevelRangeRepopsitory = riskLevelRangeRepopsitory;

        public async Task<ResponseResult<GetRiskLevelByScoreQueryResponse>> Handle(GetRiskLevelByScoreQuery request, CancellationToken cancellationToken)
        {
            var result = await _riskLevelRangeRepopsitory.GetAsync(x => x.MinScore < request.Score && request.Score < x.MaxScore);
            if (result == null)
                return new()
                {
                    Data = new(),
                    Succeeded = false
                };

            return new()
            {
                Data = new()
                {
                    RiskLevel = result.RiskLevel
                },
                Succeeded = true
            };
        }
    }
}