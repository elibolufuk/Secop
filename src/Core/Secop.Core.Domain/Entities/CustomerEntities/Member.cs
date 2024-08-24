#pragma warning disable CS8618
using Secop.Core.Domain.Enums;

namespace Secop.Core.Domain.Entities.CustomerEntities
{
    public class Member: BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public CustomerType CustomerType { get; set; }

        public DateTime DateOfBirth { get; set; }

        public ICollection<Address> Addresses { get; set; }

        public ICollection<Contact> Contacts { get; set; }
    }
}
