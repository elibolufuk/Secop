using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Secop.Core.Application.Constants;
using Secop.Core.Application.EntityConfigurations;
using Secop.Core.Domain.Entities.CreditEntities;
using Secop.Core.Application.Extensions;

namespace Secop.Credit.Persistence.EntityConfigurations
{
    public class CreditApplicationEntityConfiguration : BaseEntityConfiguration<CreditApplication>
    {
        public override void Configure(EntityTypeBuilder<CreditApplication> builder)
        {
            base.ConfigureBase(builder);
            builder.ToTable(EntityConfigurationExtensions.HasTableName<CreditApplication>(), SchemaConstants.Credit);

            builder.Property(c => c.CustomerId)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired();

            builder.Property(c => c.Amount)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired()
                .HasColumnType(EntityConfigurationConstants.DecimalColumnType);

            builder.Property(c => c.TermMonths)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired();

            builder.Property(c => c.CreditType)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired();

            builder.Property(c => c.ApplicationDate)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired()
                .HasDefaultValueSql(EntityConfigurationConstants.DateTimeColumnType);
        }
    }
}
