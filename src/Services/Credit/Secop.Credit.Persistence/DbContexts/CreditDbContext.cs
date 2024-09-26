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
        private const string _schemaDefault = DatabaseSchemaConstants.Credit;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.HasDefaultSchema(_schemaDefault);

            modelBuilder.HasPostgresEnum<CreditType>(schema: _schemaDefault);
            modelBuilder.HasPostgresEnum<EntityStatusType>(schema: _schemaDefault);
            modelBuilder.HasPostgresEnum<ApplicationStatusType>(schema: _schemaDefault);
            modelBuilder.HasPostgresEnum<CreditRiskLevelType>(schema: _schemaDefault);

            modelBuilder.Entity<Condition>().SeedData();
            modelBuilder.Entity<CreditApplication>().SeedData();
        }
    }
}