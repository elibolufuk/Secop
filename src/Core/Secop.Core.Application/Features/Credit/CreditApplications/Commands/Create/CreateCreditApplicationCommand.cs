using MediatR;
using Secop.Core.Application.Results;
using Secop.Core.Domain.Enums;

namespace Secop.Core.Application.Features.Credit.CreditApplications.Commands.Create
{
    public class CreateCreditApplicationCommand : IRequest<ResponseResult<CreateCreditApplicationCommandResponse>>
    {
        public Guid CustomerId { get; set; }
        public decimal Amount { get; set; }
        public int TermMonths { get; set; }
        public CreditType CreditType { get; set; }
    }
}