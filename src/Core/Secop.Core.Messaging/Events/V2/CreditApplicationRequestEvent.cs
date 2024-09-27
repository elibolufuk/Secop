using Secop.Core.Domain.Enums;
using Secop.Core.Messaging.Interfaces;

namespace Secop.Core.Messaging.Events.V2
{
    public class CreditApplicationRequestEvent : ICreditApplicationRequestEvent
    {
        public Guid CreditApplicationId { get; set; }
        public Guid CustomerId { get; set; }
        public decimal Amount { get; set; }
        public int TermMonths { get; set; }
        public CreditType CreditType { get; set; }
    }
}