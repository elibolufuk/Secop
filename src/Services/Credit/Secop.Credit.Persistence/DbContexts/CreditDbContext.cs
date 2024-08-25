using Microsoft.EntityFrameworkCore;
using Secop.Core.Application.Constants;
using Secop.Core.Application.Extensions;
using Secop.Core.Domain.Entities.CreditEntities;
using System.Reflection;

namespace Secop.Credit.Persistence.DbContexts
{
    public class CreditDbContext(DbContextOptions<CreditDbContext> options)
        : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.HasDefaultSchema(SchemaConstants.Credit);

            modelBuilder.Entity<Condition>().SeedData();
            modelBuilder.Entity<CreditApplication>().SeedData();
        }
    }
}