using MassTransit;
using Newtonsoft.Json;
using SagaStateMachine.Models;
using Secop.Core.Messaging.Interfaces;

namespace Secop.WorkerServices.SagaStateMachine.Models
{
    public class CreditApplicationStateMachine : MassTransitStateMachine<CreditApplicationStateInstance>
    {
        public Event<ICreditApplicationRequestEvent> CreditApplicationRequestEvent { get; set; }
        public State CreditApplicationCreated { get; private set; }

        public CreditApplicationStateMachine(ILogger<CreditApplicationStateMachine> logger)
        {
            InstanceState(x => x.CurrentState);

            Event(() => CreditApplicationRequestEvent, y => y.CorrelateBy<Guid>(state => state.CreditApplicationId, request => request.Message.CreditApplicationId)
                .SelectId(context => Guid.NewGuid()));

            Initially(
                When(CreditApplicationRequestEvent)
                .Then(context =>
                {
                    context.Saga.CreditApplicationId = context.Message.CreditApplicationId;
                    context.Saga.CustomerId = context.Message.CustomerId;
                    context.Saga.Amount = context.Message.Amount;
                    context.Saga.TermMonths = context.Message.TermMonths;
                    context.Saga.CreditType = context.Message.CreditType;
                    context.Saga.CreatedDate = DateTime.Now;
                })
                .Then(context =>
                {
                    logger.LogInformation($"{nameof(ICreditApplicationRequestEvent)} receipt Event : {{Event}}", JsonConvert.SerializeObject(context.Message));
                })
                .TransitionTo(CreditApplicationCreated)
                .Then(context =>
                {
                    logger.LogInformation($"{nameof(ICreditApplicationRequestEvent)} processed {{Request}}", JsonConvert.SerializeObject(context.Message));
                }));
        }
    }
}