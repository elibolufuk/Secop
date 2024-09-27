using MassTransit;
using MediatR;
using Newtonsoft.Json;
using Secop.Core.Messaging.Events.V1;
using Secop.Core.Application.Features.Credit.CreditApplications.Commands.Update;

namespace Secop.Credit.Web.Api.V1.Consumers
{
    public class LoanApprovalCreatedEventConsumer(IMediator mediator, ILogger<LoanApprovalCreatedEventConsumer> logger)
        : IConsumer<LoanApprovalCreatedEvent>
    {
        private readonly IMediator _mediator = mediator;
        private readonly ILogger<LoanApprovalCreatedEventConsumer> _logger = logger;

        public async Task Consume(ConsumeContext<LoanApprovalCreatedEvent> context)
        {
            _logger.LogInformation($"{nameof(LoanApprovalCreatedEvent)} receipt Event : {{Event}}", JsonConvert.SerializeObject(context.Message));

            var updateCreditApplicationCommand = new UpdateCreditApplicationCommand
            {
                Id = context.Message.CreditApplicationId,
                ApplicationStatus = context.Message.ApplicationStatus,
                RiskLevel = context.Message.RiskLevel,
                Comment = context.Message.Comment
            };
            var result = await _mediator.Send(updateCreditApplicationCommand);

            if (!result.Succeeded)
            {
                _logger.LogError("Credit Application update could not save : {Request}, Response : {Response}", JsonConvert.SerializeObject(context.Message), JsonConvert.SerializeObject(result));
                return;
            }
            _logger.LogInformation($"Credit Application updated");
        }
    }
}