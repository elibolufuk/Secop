using Microsoft.EntityFrameworkCore;
using Secop.Core.Application.Constants;
using Secop.Core.Application.Extensions;
using Secop.Core.Domain.Entities.CustomerEntities;
using Secop.Core.Domain.Enums;
using System.Reflection;

namespace Secop.Customer.Persistence.DbContexts
{
    public class CustomerDbContext(DbContextOptions<CustomerDbContext> options)
        : DbContext(options)
    {
        private readonly string _schemaDefault = DatabaseSchemaConstants.Customer;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.HasDefaultSchema(_schemaDefault);

            modelBuilder.HasPostgresEnum<CustomerType>(schema: _schemaDefault);
            modelBuilder.HasPostgresEnum<EntityStatusType>(schema: _schemaDefault);

            modelBuilder.Entity<Address>().SeedData();
            modelBuilder.Entity<Contact>().SeedData();
            modelBuilder.Entity<Member>().SeedData();
        }
    }
}