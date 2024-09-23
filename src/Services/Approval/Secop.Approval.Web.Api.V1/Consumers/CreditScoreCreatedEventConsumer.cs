using AutoMapper;
using MassTransit;
using MediatR;
using Newtonsoft.Json;
using Secop.Core.ApiCommon.Events.V1;
using Secop.Core.Application.Features.Approval.LoanApprovals.Commands.Create;

namespace Secop.Approval.Web.Api.V1.Consumers
{
    public class CreditScoreCreatedEventConsumer(IPublishEndpoint publishEndpoint, IMediator mediator, IMapper mapper,
        ILogger<CreditScoreCreatedEventConsumer> logger)
        : IConsumer<CreditScoreCreatedEvent>
    {
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;
        private readonly IMediator _mediator = mediator;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<CreditScoreCreatedEventConsumer> _logger = logger;

        public async Task Consume(ConsumeContext<CreditScoreCreatedEvent> context)
        {
            _logger.LogInformation($"{nameof(CreditScoreCreatedEvent)} receipt Event : {{Event}}", JsonConvert.SerializeObject(context.Message));

            var command = _mapper.Map<CreateLoanApprovalCommand>(context.Message);
            var response = await _mediator.Send(command);

            if (!response.Succeeded)
            {
                _logger.LogError("Loan Approval could not save : {Request}, Response : {Response}", JsonConvert.SerializeObject(context.Message), JsonConvert.SerializeObject(response));

                var loanApprovalNotCreatedEvent = new LoanApprovalNotCreatedEvent { CreditApplicationId = context.Message.CreditApplicationId };
                await _publishEndpoint.Publish(loanApprovalNotCreatedEvent);
                _logger.LogInformation($"{nameof(LoanApprovalNotCreatedEvent)} Publish : {{LoanApprovalNotCreatedEvent}}", JsonConvert.SerializeObject(loanApprovalNotCreatedEvent));
            }

            var loanApprovalCreatedEvent = _mapper.Map<LoanApprovalCreatedEvent>(response.Data);
            await _publishEndpoint.Publish(loanApprovalCreatedEvent);

            _logger.LogInformation($"{nameof(LoanApprovalCreatedEvent)} Publish : {{LoanApprovalCreatedEvent}}", JsonConvert.SerializeObject(loanApprovalCreatedEvent));
        }
    }
}
