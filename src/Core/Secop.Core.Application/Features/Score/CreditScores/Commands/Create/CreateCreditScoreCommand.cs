using MediatR;
using Secop.Core.Application.Results;

namespace Secop.Core.Application.Features.Score.CreditScores.Commands.Create
{
    public class CreateCreditScoreCommand
        : IRequest<ResponseResult<CreateCreditScoreCommandResponse>>
    {
        public Guid CustomerId { get; set; }
    }
}
