using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Secop.Core.Application.EntityConfigurations;
using Secop.Core.Domain.Entities.CreditEntities;

namespace Secop.Credit.Persistence.EntityConfigurations
{
    public class ConditionEntityConfiguration : BaseEntityConfiguration<Condition>
    {
        public override void Configure(EntityTypeBuilder<Condition> builder)
        {
            base.ConfigureBase(builder);
            builder.ToTable("condition", "Credit", t =>
            {
                t.HasCheckConstraint($"CHK_{nameof(Condition)}_MinMonth", "min_month >= 1");
                t.HasCheckConstraint($"CHK_{nameof(Condition)}_MaxMonth", "max_month >= 1");
            });

            // TODO : postgre enum ile ilişkilendirilecek
            builder.Property(c => c.CreditType)
                .HasColumnName("credit_type")
                .IsRequired().HasMaxLength(50);

            builder.Property(c => c.InterestRate)
                .HasColumnName("interest_rate")
                .IsRequired().HasColumnType("decimal(18,2)");

            builder.Property(c => c.MinAmount)
                .HasColumnName("min_amount")
                .IsRequired().HasColumnType("decimal(18,2)");

            builder.Property(c => c.MaxAmount)
                .HasColumnName("max_amount")
                .IsRequired().HasColumnType("decimal(18,2)");

            builder.Property(c => c.MinMonth)
                .HasColumnName("min_month")
                .IsRequired().HasMaxLength(120);

            builder.Property(c => c.MaxMonth)
                .HasColumnName("max_month")
                .IsRequired();
        }
    }
}
