using Microsoft.EntityFrameworkCore;

namespace Secop.Approval.Persistence.DbContexts
{
    public class ApprovalDbContext(DbContextOptions<ApprovalDbContext> options)
        : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}