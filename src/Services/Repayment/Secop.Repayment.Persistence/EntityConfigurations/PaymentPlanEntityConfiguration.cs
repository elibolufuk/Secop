using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Secop.Core.Application.Constants;
using Secop.Core.Application.EntityConfigurations;
using Secop.Core.Application.Extensions;
using Secop.Core.Domain.Entities.RepaymentEntities;

namespace Secop.Repayment.Persistence.EntityConfigurations
{
    public class PaymentPlanEntityConfiguration
        : BaseEntityConfiguration<PaymentPlan>
    {
        private const string _databaseSchema = DatabaseSchemaConstants.Repayment;
        public override void Configure(EntityTypeBuilder<PaymentPlan> builder)
        {
            base.ConfigureBase(builder);
            builder.ToTable(EntityConfigurationExtensions.HasTableName<PaymentPlan>(), _databaseSchema);

            builder.Property(la => la.CreditApplicationId)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired();

            builder.Property(la => la.Amount)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .HasColumnType(EntityConfigurationConstants.DecimalColumnType)
                .IsRequired();

            builder.Property(la => la.InstallmentOrder)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired();

            builder.Property(la => la.LastPaymentDate)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired();

            builder.Property(la => la.PaymentStatus)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .HasDefaultValue(false)
                .IsRequired();
        }
    }
}
