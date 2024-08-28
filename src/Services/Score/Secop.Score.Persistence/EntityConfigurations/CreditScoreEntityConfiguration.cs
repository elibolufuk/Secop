using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Secop.Core.Application.Constants;
using Secop.Core.Application.EntityConfigurations;
using Secop.Core.Application.Extensions;
using Secop.Core.Domain.Entities.ScoreEntities;

namespace Secop.Score.Persistence.EntityConfigurations
{
    public class CreditScoreEntityConfiguration : BaseEntityConfiguration<CreditScore>
    {
        public override void Configure(EntityTypeBuilder<CreditScore> builder)
        {
            base.ConfigureBase(builder);

            builder.ToTable(EntityConfigurationExtensions.HasTableName<CreditScore>(), SchemaConstants.Score);

            builder.Property(cs => cs.CustomerId)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired();

            builder.Property(cs => cs.Score)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired();

            builder.Property(cs => cs.ScoreDate)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired();

            builder.Property(cs => cs.RiskLevel)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired();
        }
    }
}
