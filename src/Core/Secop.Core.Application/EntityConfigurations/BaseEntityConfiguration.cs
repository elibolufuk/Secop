using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Secop.Core.Domain.Entities;
using Secop.Core.Domain.Enums;

namespace Secop.Core.Application.EntityConfigurations
{
    public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity :
    BaseEntity
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
                .HasColumnOrder(ColumnOrder);

            builder.Property(p => p.CreatedById)
                .IsRequired()
                .HasColumnOrder(ColumnOrder);

            builder.Property(p => p.UpdatedById)
                .IsRequired(false)
                .HasColumnOrder(ColumnOrder);

            builder.Property(p => p.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnOrder(ColumnOrder);

            builder.Property(p => p.UpdatedAt)
                .IsRequired(false)
                .HasColumnOrder(ColumnOrder);

            builder.Property(p => p.EntityStatus)
                .IsRequired()
                .HasDefaultValue(EntityStatusType.Active)
                .HasColumnOrder(ColumnOrder);
        }
    }
}