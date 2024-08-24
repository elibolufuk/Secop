#pragma warning disable CS8618
namespace Secop.Core.Domain.Entities.CustomerEntities
{
    public class Contact: BaseEntity
    {
        public string PhoneNumber { get; set; }

        public string ContactType { get; set; }

        public int MemberId { get; set; }

        public Member Member { get; set; }
    }
}
