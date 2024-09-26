using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Secop.Core.Application.Constants;
using Secop.Core.Application.EntityConfigurations;
using Secop.Core.Application.Extensions;
using Secop.Core.Domain.Entities.ScoreEntities;

namespace Secop.Score.Persistence.EntityConfigurations
{
    public class RiskLevelRangeEntityConfiguration : BaseEntityConfiguration<RiskLevelRange>
    {
        private const string _databaseSchema = DatabaseSchemaConstants.Score;
        public override void Configure(EntityTypeBuilder<RiskLevelRange> builder)
        {
            base.ConfigureBase(builder);

            var tableName = EntityConfigurationExtensions.HasTableName<RiskLevelRange>();
            builder.ToTable(tableName, _databaseSchema, t =>
            {
                var minScore = EntityConfigurationExtensions.GetColumnName<RiskLevelRange>(rl => rl.MinScore);
                var maxScore = EntityConfigurationExtensions.GetColumnName<RiskLevelRange>(rl => rl.MaxScore);

                t.HasCheckConstraint($"CHK_{tableName}_{minScore}_{maxScore}", $"{minScore} <= {maxScore}");

            });

            builder.Property(rl => rl.RiskLevel)
                    .HasColumnDefaultName()
                    .HasColumnOrder(ColumnOrder)
                    .IsRequired();

            builder.Property(rl => rl.MinScore)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired();

            builder.Property(rl => rl.MaxScore)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired();
        }
    }
}
