using Microsoft.EntityFrameworkCore;
using Secop.Core.Application.Constants;
using Secop.Core.Application.Extensions;
using Secop.Core.Domain.Entities.ScoreEntities;
using Secop.Core.Domain.Enums;
using System.Reflection;

namespace Secop.Score.Persistence.DbContexts
{
    public class ScoreDbContext(DbContextOptions<ScoreDbContext> options)
        : DbContext(options)
    {
        private readonly string _schemaDefault = DatabaseSchemaConstants.Score;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.HasDefaultSchema(_schemaDefault);

            modelBuilder.HasPostgresEnum<CreditRiskLevelType>(schema: _schemaDefault);
            modelBuilder.HasPostgresEnum<EntityStatusType>(schema: _schemaDefault);

            modelBuilder.Entity<RiskLevelRange>().SeedData();
            modelBuilder.Entity<CreditScore>().SeedData();
        }
    }
}