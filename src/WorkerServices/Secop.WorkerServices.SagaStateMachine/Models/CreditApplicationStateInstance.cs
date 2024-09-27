using MassTransit;
using Secop.Core.Domain.Enums;

namespace SagaStateMachine.Models
{
    public class CreditApplicationStateInstance : SagaStateMachineInstance, ISagaVersion
    {
        public Guid CorrelationId { get; set; }
        public string CurrentState { get; set; }

        public Guid CreditApplicationId { get; set; }
        public Guid CustomerId { get; set; }
        public decimal Amount { get; set; }
        public int TermMonths { get; set; }
        public CreditType CreditType { get; set; }

        public DateTime CreatedDate { get; set; }
        public int Version { get; set; }
    }
}