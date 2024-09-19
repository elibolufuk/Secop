#pragma warning disable CS8618

using Secop.Core.Domain.Enums;

namespace Secop.Core.Domain.Entities.CreditEntities
{
    public class CreditApplication : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public decimal Amount { get; set; }
        public int TermMonths { get; set; }
        public CreditType CreditType { get; set; }
        public DateTime ApplicationDate { get; set; }
        public CreditRiskLevelType RiskLevelType { get; set; }
        public ApplicationStatusType ApplicationStatus { get; set; }
        public string Comment { get; set; }
    }
}