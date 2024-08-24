using Microsoft.EntityFrameworkCore;

namespace Secop.Score.Persistence.DbContexts
{
    public class ScoreDbContext(DbContextOptions<ScoreDbContext> options)
        : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}