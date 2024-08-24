using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Secop.Score.Persistence.DbContexts;

namespace Secop.Score.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceCollections(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionStringsSection = configuration.GetConnectionString(nameof(ScoreDbContext));
            services.AddDbContext<ScoreDbContext>(options => options.UseNpgsql(connectionStringsSection));
            return services;
        }
    }
}