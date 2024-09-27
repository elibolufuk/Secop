using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SagaStateMachine.Models;

namespace Secop.WorkerServices.SagaStateMachine.Models
{
    public class CreditApplicationStateMapping : SagaClassMap<CreditApplicationStateInstance>
    {
        protected override void Configure(EntityTypeBuilder<CreditApplicationStateInstance> entity, ModelBuilder model)
        {
            base.Configure(entity, model);
            entity.Property(x => x.CreditApplicationId).IsRequired();
            entity.Property(x => x.CustomerId).IsRequired();
            entity.Property(x => x.Amount).IsRequired();
            entity.Property(x => x.TermMonths).IsRequired();
            entity.Property(x => x.CreditType).IsRequired();
        }
    }
}