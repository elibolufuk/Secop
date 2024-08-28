using Microsoft.EntityFrameworkCore;
using Secop.Core.Application.Constants;
using Secop.Core.Application.Extensions;
using Secop.Core.Domain.Entities.CreditEntities;
using Secop.Core.Domain.Enums;
using System.Reflection;

namespace Secop.Credit.Persistence.DbContexts
{
    public class CreditDbContext(DbContextOptions<CreditDbContext> options)
        : DbContext(options)
    {
        private const string SchemaDefault = SchemaConstants.Credit;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.HasDefaultSchema(SchemaConstants.Credit);

            modelBuilder.HasPostgresEnum<CreditType>(schema: SchemaDefault);
            modelBuilder.HasPostgresEnum<EntityStatusType>(schema: SchemaDefault);

            modelBuilder.Entity<Condition>().SeedData();
            modelBuilder.Entity<CreditApplication>().SeedData();
        }
    }
}