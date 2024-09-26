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
        private readonly string _schemaDefault = DatabaseSchemaConstants.Approval;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.HasDefaultSchema(_schemaDefault);

            modelBuilder.HasPostgresEnum<CreditRiskLevelType>(schema: _schemaDefault);
            modelBuilder.HasPostgresEnum<ApplicationStatusType>(schema: _schemaDefault);
            modelBuilder.HasPostgresEnum<EntityStatusType>(schema: _schemaDefault);

            modelBuilder.Entity<LoanApproval>().SeedData();
        }
    }
}