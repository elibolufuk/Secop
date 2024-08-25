using Microsoft.EntityFrameworkCore;
using Secop.Core.Application.Constants;
using Secop.Core.Application.Extensions;
using Secop.Core.Domain.Entities.ScoreEntities;
using System.Reflection;

namespace Secop.Score.Persistence.DbContexts
{
    public class ScoreDbContext(DbContextOptions<ScoreDbContext> options)
        : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.HasDefaultSchema(SchemaConstants.Score);

            modelBuilder.Entity<RiskLevelRange>().SeedData();
            modelBuilder.Entity<CreditScore>().SeedData();
        }
    }
}