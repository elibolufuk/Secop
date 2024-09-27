using Secop.Core.Domain.Enums;

namespace Secop.Core.Messaging.Interfaces
{
    public interface ICreditApplicationRequestEvent
    {
        Guid CreditApplicationId { get; set; }
        Guid CustomerId { get; set; }
        decimal Amount { get; set; }
        int TermMonths { get; set; }
        CreditType CreditType { get; set; }
    }
}
