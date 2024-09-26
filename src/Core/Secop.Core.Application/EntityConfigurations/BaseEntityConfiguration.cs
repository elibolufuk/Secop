using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Secop.Core.Application.Constants;
using Secop.Core.Application.Extensions;
using Secop.Core.Domain.Entities;
using Secop.Core.Domain.Enums;

namespace Secop.Core.Application.EntityConfigurations
{
    public abstract class BaseEntityConfiguration<TEntity>
        : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity
    {
        private int _columnOrder = 0;
        protected int ColumnOrder => ++_columnOrder;

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {

        }

        protected void ConfigureBase(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasIndex(k => k.Id);

            builder.Property(p => p.Id)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder);

            builder.Property(p => p.CreatedById)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired();

            builder.Property(p => p.CreatedAt)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired()
                .HasDefaultValueSql(EntityConfigurationConstants.DateTimeColumnType);

            builder.Property(p => p.UpdatedById)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired(false);

            builder.Property(p => p.UpdatedAt)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired(false);

            builder.Property(p => p.EntityStatus)
                .HasColumnDefaultName()
                .HasColumnOrder(ColumnOrder)
                .IsRequired()
                .HasDefaultValue(EntityStatusType.Active);
        }
    }
}