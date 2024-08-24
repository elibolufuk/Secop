using Microsoft.EntityFrameworkCore;

namespace Secop.Credit.Persistence.DbContexts
{
    public class CreditDbContext(DbContextOptions<CreditDbContext> options)
        : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}