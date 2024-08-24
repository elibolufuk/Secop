using Microsoft.EntityFrameworkCore;

namespace Secop.Customer.Persistence.DbContexts
{
    public class CustomerDbContext(DbContextOptions<CustomerDbContext> options)
        : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}