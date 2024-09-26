using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Secop.Core.Application.EntityConfigurations;
using Secop.Core.Domain.Entities.CustomerEntities;
using Secop.Core.Application.Extensions;
using Secop.Core.Application.Constants;

namespace Secop.Customer.Persistence.EntityConfigurations
{
    public class MemberEntityConfiguration : BaseEntityConfiguration<Member>
    {
        private const string _databaseSchema = DatabaseSchemaConstants.Customer;
        public override void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable(EntityConfigurationExtensions.HasTableName<Member>(), _databaseSchema);

            builder.HasKey(m => m.Id);

            builder.Property(m => m.FirstName)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(m => m.LastName)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(m => m.Email)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(m => m.CustomerType)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired();

            builder.Property(m => m.DateOfBirth)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired();

            builder.HasMany(m => m.Addresses)
                .WithOne(a => a.Member)
                .HasForeignKey(a => a.MemberId);

            builder.HasMany(m => m.Contacts)
                .WithOne(c => c.Member)
                .HasForeignKey(c => c.MemberId);
        }
    }
}
