using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Secop.Core.Application.Constants;
using Secop.Core.Application.EntityConfigurations;
using Secop.Core.Domain.Entities.ApprovalEntities;
using Secop.Core.Application.Extensions;

namespace Secop.Approval.Persistence.EntityConfigurations
{
    public class LoanApprovalEntityConfiguration : BaseEntityConfiguration<LoanApproval>
    {
        public override void Configure(EntityTypeBuilder<LoanApproval> builder)
        {
            base.ConfigureBase(builder);

            builder.ToTable(EntityConfigurationExtensions.HasTableName<LoanApproval>(), DatabaseSchemaConstants.Approval);

            builder.Property(la => la.CreditApplicationId)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired();

            builder.Property(la => la.Amount)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .HasColumnType(EntityConfigurationConstants.DecimalColumnType)
                .IsRequired();

            builder.Property(la => la.TermMonths)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired();

            builder.Property(la => la.Score)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired();

            builder.Property(la => la.RiskLevel)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired();

            builder.Property(la => la.ApplicationStatus)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired();

            builder.Property(la => la.Comment).HasColumnDefaultName().HasColumnOrder(ColumnOrder)
                .HasMaxLength(500);
        }
    }
}