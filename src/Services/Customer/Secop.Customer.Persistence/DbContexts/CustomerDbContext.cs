using Microsoft.EntityFrameworkCore;
using Secop.Core.Application.Constants;
using System.Reflection;

namespace Secop.Customer.Persistence.DbContexts
{
    public class CustomerDbContext(DbContextOptions<CustomerDbContext> options)
        : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.HasDefaultSchema(SchemaConstants.Customer);
        }
    }
}