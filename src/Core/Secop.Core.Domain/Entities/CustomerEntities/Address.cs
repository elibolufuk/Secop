#pragma warning disable CS8618
namespace Secop.Core.Domain.Entities.CustomerEntities
{
    public class Address: BaseEntity
    {
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public Guid MemberId { get; set; }

        public Member Member { get; set; }
    }
}
