using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Secop.Approval.Persistence.DbContexts
{
    public class ApprovalDbContext(DbContextOptions<ApprovalDbContext> options)
        : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}