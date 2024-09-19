using MediatR;
using Secop.Core.Application.Results;

namespace Secop.Core.Application.Features.Credit.CreditApplications.Commands.SoftDelete
{
    public class SoftDeleteCreditApplicationCommand : IRequest<BaseResponseResult>
    {
        public Guid Id { get; set; }
    }
}
