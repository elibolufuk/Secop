namespace Secop.Core.ApiCommon.Events
{
    public class CreditScoreNotCreatedEvent
    {
        public Guid CreditApplicationId { get; set; }
        public string Message { get; set; }
    }
}