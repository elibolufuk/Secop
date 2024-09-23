using Secop.Core.Domain.Enums;

namespace Secop.Core.ApiCommon.Events.V1
{
    public class CreditApplicationCreatedEvent
    {
        public Guid CreditApplicationId { get; set; }
        public Guid CustomerId { get; set; }
        public decimal Amount { get; set; }
        public int TermMonths { get; set; }
        public CreditType CreditType { get; set; }
    }
}