using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Secop.Core.Application.Constants;
using Secop.Core.Application.EntityConfigurations;
using Secop.Core.Domain.Entities.CreditEntities;
using Secop.Core.Application.Extensions;
using Secop.Core.Domain.Enums;

namespace Secop.Credit.Persistence.EntityConfigurations
{
    public class CreditApplicationEntityConfiguration : BaseEntityConfiguration<CreditApplication>
    {
        public override void Configure(EntityTypeBuilder<CreditApplication> builder)
        {
            base.ConfigureBase(builder);
            builder.ToTable(EntityConfigurationExtensions.HasTableName<CreditApplication>(), DatabaseSchemaConstants.Credit);

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


            builder.Property(p => p.RiskLevelType)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired()
                .HasDefaultValue(CreditRiskLevelType.None);

            builder.Property(p => p.ApplicationStatus)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired()
                .HasDefaultValue(ApplicationStatusType.ApplicationReceived);

            builder.Property(p => p.Comment)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .HasMaxLength(500)
                .IsRequired(false);
        }
    }
}
