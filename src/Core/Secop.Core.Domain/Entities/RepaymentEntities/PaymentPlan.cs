namespace Secop.Core.Domain.Entities.RepaymentEntities
{
    public class PaymentPlan : BaseEntity
    {
        public Guid CreditApplicationId { get; set; }
        public decimal Amount { get; set; }
        public byte InstallmentOrder { get; set; }
        public DateTime LastPaymentDate { get; set; }
        public bool PaymentStatus { get; set; }
    }
}