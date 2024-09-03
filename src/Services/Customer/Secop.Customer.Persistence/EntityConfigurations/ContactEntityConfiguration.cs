using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Secop.Core.Application.Constants;
using Secop.Core.Application.EntityConfigurations;
using Secop.Core.Application.Extensions;
using Secop.Core.Domain.Entities.CustomerEntities;

namespace Secop.Customer.Persistence.EntityConfigurations
{
    public class ContactEntityConfiguration : BaseEntityConfiguration<Contact>
    {
        public override void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable(EntityConfigurationExtensions.HasTableName<Contact>(), DatabaseSchemaConstants.Customer);

            builder.Property(c => c.PhoneNumber)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(c => c.ContactType)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(c => c.Member)
                .WithMany(m => m.Contacts)
                .HasForeignKey(c => c.MemberId);
        }
    }
}
