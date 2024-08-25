using Microsoft.EntityFrameworkCore;
using Secop.Core.Application.Constants;
using Secop.Core.Application.Extensions;
using Secop.Core.Domain.Entities.ApprovalEntities;
using System.Reflection;

namespace Secop.Approval.Persistence.DbContexts
{
    public class ApprovalDbContext(DbContextOptions<ApprovalDbContext> options)
        : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.HasDefaultSchema(SchemaConstants.Approval);

            modelBuilder.Entity<LoanApproval>().SeedData();
        }
    }
}