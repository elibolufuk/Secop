using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Secop.Core.Application.Constants;
using Secop.Core.Application.EntityConfigurations;
using Secop.Core.Domain.Entities.CreditEntities;
using Secop.Core.Application.Extensions;

namespace Secop.Credit.Persistence.EntityConfigurations
{
    public class ConditionEntityConfiguration : BaseEntityConfiguration<Condition>
    {
        private const string _databaseSchema = DatabaseSchemaConstants.Credit;

        public override void Configure(EntityTypeBuilder<Condition> builder)
        {
            base.ConfigureBase(builder);
            var tableName = EntityConfigurationExtensions.HasTableName<Condition>();
            builder.ToTable(tableName, _databaseSchema, t =>
            {
                var minMonth = EntityConfigurationExtensions.GetColumnName<Condition>(rl => rl.MinMonth);
                var maxMonth = EntityConfigurationExtensions.GetColumnName<Condition>(rl => rl.MaxMonth);

                t.HasCheckConstraint($"CHK_{tableName}_{minMonth}", $"{minMonth} >= 1 AND {minMonth} <= 120");
                t.HasCheckConstraint($"CHK_{tableName}_{maxMonth}", $"{maxMonth} >= 1 AND {maxMonth} <= 120");
            });

            builder.Property(c => c.CreditType)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired().HasMaxLength(50);

            builder.Property(c => c.InterestRate)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired().HasColumnType(EntityConfigurationConstants.DecimalColumnType);

            builder.Property(c => c.MinAmount)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired().HasColumnType(EntityConfigurationConstants.DecimalColumnType);

            builder.Property(c => c.MaxAmount)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired().HasColumnType(EntityConfigurationConstants.DecimalColumnType);

            builder.Property(c => c.MinMonth)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired().HasMaxLength(120);

            builder.Property(c => c.MaxMonth)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired();
        }
    }
}