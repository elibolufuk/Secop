using Microsoft.EntityFrameworkCore;
using Secop.Core.Application.Constants;
using System.Reflection;

namespace Secop.Repayment.Persistence.DbContexts
{
    public class RepaymentDbContext(DbContextOptions<RepaymentDbContext> options)
        : DbContext(options)
    {
        private readonly string _schemaDefault = DatabaseSchemaConstants.Repayment;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.HasDefaultSchema(_schemaDefault);
        }
    }
}