namespace Secop.Core.Messaging.Events.V1
{
    public class CreditScoreNotCreatedEvent
    {
        public Guid CreditApplicationId { get; set; }
        public string? Message { get; set; }
    }
}