using MediatR;
using Secop.Core.Application.Results;

namespace Secop.Core.Application.Features.Score.RiskLevelRange.Queries.GetRiskLevelByScore
{
    public class GetRiskLevelByScoreQuery : IRequest<ResponseResult<GetRiskLevelByScoreQueryResponse>>
    {
        public int Score { get; set; }
    }
}
