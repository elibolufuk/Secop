using Microsoft.EntityFrameworkCore;
using Secop.Core.Application.Constants;
using Secop.Core.Application.Extensions;
using Secop.Core.Domain.Entities.ApprovalEntities;
using Secop.Core.Domain.Enums;
using System.Reflection;

namespace Secop.Approval.Persistence.DbContexts
{
    public class ApprovalDbContext(DbContextOptions<ApprovalDbContext> options)
        : DbContext(options)
    {
        private const string SchemaDefault = SchemaConstants.Approval;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.HasDefaultSchema(SchemaDefault);

            modelBuilder.HasPostgresEnum<CreditRiskLevelType>(schema: SchemaDefault);
            modelBuilder.HasPostgresEnum<ApplicationStatusType>(schema: SchemaDefault);
            modelBuilder.HasPostgresEnum<EntityStatusType>(schema: SchemaDefault);

            modelBuilder.Entity<LoanApproval>().SeedData();
        }
    }
}