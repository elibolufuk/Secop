using Microsoft.EntityFrameworkCore;
using Secop.Core.Application.Constants;
using Secop.Core.Application.Extensions;
using Secop.Core.Domain.Entities.CustomerEntities;
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

            modelBuilder.Entity<Address>().SeedData();
            modelBuilder.Entity<Contact>().SeedData();
            modelBuilder.Entity<Member>().SeedData();
        }
    }
}