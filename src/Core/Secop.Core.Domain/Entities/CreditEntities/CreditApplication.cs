#pragma warning disable CS8618

using Secop.Core.Domain.Enums;

namespace Secop.Core.Domain.Entities.CreditEntities
{
    public class CreditApplication : BaseEntity
    {
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public int TermMonths { get; set; }
        public CreditType CreditType { get; set; }
        public DateTime ApplicationDate { get; set; }
    }
}