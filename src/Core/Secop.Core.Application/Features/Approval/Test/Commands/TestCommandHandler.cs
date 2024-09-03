using MediatR;
using Secop.Core.Application.Attributes;
using Secop.Core.Application.Constants;

namespace Secop.Core.Application.Features.Approval.Test.Commands
{
    [ServiceHandler(ServiceHandlerType.Approval)]
    internal class TestCommandHandler : IRequestHandler<TestCommand, string>
    {
        public Task<string> Handle(TestCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
