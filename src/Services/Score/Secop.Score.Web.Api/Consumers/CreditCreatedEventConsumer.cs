using AutoMapper;
using MassTransit;
using MediatR;
using Newtonsoft.Json;
using Secop.Core.ApiCommon.Constants;
using Secop.Core.ApiCommon.Events;
using Secop.Core.Application.Features.Score.CreditScores.Commands.Create;

namespace Secop.Score.Web.Api.Consumers
{
    public class CreditCreatedEventConsumer(IMediator mediator, IMapper mapper, IPublishEndpoint publishEndpoint, ISendEndpointProvider sendEndpointProvider,
        ILogger<CreditCreatedEventConsumer> logger)
        : IConsumer<CreditApplicationCreatedEvent>
    {
        private readonly IMediator _mediator = mediator;
        private readonly IMapper _mapper = mapper;
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;
        private readonly ISendEndpointProvider _sendEndpointProvider = sendEndpointProvider;
        private readonly ILogger<CreditCreatedEventConsumer> _logger = logger;

        public async Task Consume(ConsumeContext<CreditApplicationCreatedEvent> context)
        {
            _logger.LogInformation($"{nameof(CreditApplicationCreatedEvent)} receipt Event : {{Event}}", JsonConvert.SerializeObject(context.Message));
            var createCreditScoreCommand = _mapper.Map<CreateCreditScoreCommand>(context.Message);
            var response = await _mediator.Send(createCreditScoreCommand);

            if (!response.Succeeded)
            {
                _logger.LogError("Credit Score could not save : {Request}, Response : {Response}", JsonConvert.SerializeObject(context.Message), JsonConvert.SerializeObject(response));

                var creditScoreNotCreatedEvent = new CreditScoreNotCreatedEvent
                {
                    CreditApplicationId = context.Message.CreditApplicationId,
                    Message = "An error occurred."
                };

                await _publishEndpoint.Publish(creditScoreNotCreatedEvent);
                _logger.LogInformation($"{nameof(CreditScoreNotCreatedEvent)} Publish : {{CreditScoreNotCreatedEvent}}", JsonConvert.SerializeObject(creditScoreNotCreatedEvent));
            }

            var creditScoreCreatedEvent = _mapper.Map<CreditScoreCreatedEvent>(response.Data);
            creditScoreCreatedEvent.CreditApplicationId = context.Message.CreditApplicationId;
            creditScoreCreatedEvent.Score = response.Data.Score;
            creditScoreCreatedEvent.RiskLevel = response.Data.RiskLevel;
            creditScoreCreatedEvent.Amount = context.Message.Amount;
            creditScoreCreatedEvent.TermMonths = context.Message.TermMonths;
            creditScoreCreatedEvent.CustomerId = context.Message.CustomerId;

            var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{QueueNameConstants.ScoreCreditCreatedQueueName}"));
            await sendEndpoint.Send(creditScoreCreatedEvent);

            _logger.LogInformation($"{nameof(CreditScoreCreatedEvent)} GetSendEndpoint : {{CreditScoreCreatedEvent}}", JsonConvert.SerializeObject(creditScoreCreatedEvent));
        }
    }
}