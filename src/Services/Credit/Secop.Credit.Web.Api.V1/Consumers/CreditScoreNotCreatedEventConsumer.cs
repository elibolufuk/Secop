using MassTransit;
using MediatR;
using Newtonsoft.Json;
using Secop.Core.ApiCommon.Events.V1;
using Secop.Core.Application.Features.Credit.CreditApplications.Commands.SoftDelete;

namespace Secop.Credit.Web.Api.V1.Consumers
{
    public class CreditScoreNotCreatedEventConsumer(IMediator mediator, ILogger<CreditScoreNotCreatedEventConsumer> logger)
        : IConsumer<CreditScoreNotCreatedEvent>
    {
        private readonly IMediator _mediator = mediator;
        private readonly ILogger<CreditScoreNotCreatedEventConsumer> _logger = logger;
        public async Task Consume(ConsumeContext<CreditScoreNotCreatedEvent> context)
        {
            _logger.LogInformation($"{nameof(CreditScoreNotCreatedEvent)} receipt Event : {{Event}}", JsonConvert.SerializeObject(context.Message));
            var command = new SoftDeleteCreditApplicationCommand { Id = context.Message.CreditApplicationId };
            var result = await _mediator.Send(command);
            if (!result.Succeeded)
            {
                _logger.LogError("Credit Application softdelete could not save : {Request}, Response : {Response}", JsonConvert.SerializeObject(context.Message), JsonConvert.SerializeObject(result));
                return;
            }

            _logger.LogInformation($"Credit Application softdeleted");
        }
    }
}