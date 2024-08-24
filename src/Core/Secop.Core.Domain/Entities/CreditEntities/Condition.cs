using Secop.Core.Domain.Enums;

namespace Secop.Core.Domain.Entities.CreditEntities
{
    public class Condition : BaseEntity
    {
        public CreditType CreditType { get; set; }
        public decimal InterestRate { get; set; }
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
        public byte MinMonth { get; set; }
        public byte MaxMonth { get; set; }
    }
}