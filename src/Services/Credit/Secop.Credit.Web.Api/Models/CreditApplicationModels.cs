using Secop.Core.Domain.Enums;

namespace Secop.Credit.Web.Api.Models
{
    public class CreditApplicationModels
    {
        public Guid CustomerId { get; set; }

        public decimal Amount { get; set; }

        public int TermMonths { get; set; }

        public CreditType CreditType { get; set; }
    }
}
