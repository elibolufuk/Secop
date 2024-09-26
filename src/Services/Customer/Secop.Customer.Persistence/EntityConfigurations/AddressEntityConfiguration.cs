using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Secop.Core.Application.Constants;
using Secop.Core.Application.EntityConfigurations;
using Secop.Core.Application.Extensions;
using Secop.Core.Domain.Entities.CustomerEntities;

namespace Secop.Customer.Persistence.EntityConfigurations
{
    public class AddressEntityConfiguration : BaseEntityConfiguration<Address>
    {
        private const string _databaseSchema = DatabaseSchemaConstants.Customer;
        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable(EntityConfigurationExtensions.HasTableName<Address>(), _databaseSchema);

            builder.Property(a => a.AddressLine1)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(a => a.AddressLine2)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .HasMaxLength(200);

            builder.Property(a => a.City)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.State)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .HasMaxLength(100);

            builder.Property(a => a.PostalCode)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(a => a.Country)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(a => a.Member)
                .WithMany(m => m.Addresses)
                .HasForeignKey(a => a.MemberId);
        }
    }
}
