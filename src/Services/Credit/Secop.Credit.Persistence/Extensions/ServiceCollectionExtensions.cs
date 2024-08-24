using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Secop.Credit.Persistence.DbContexts;

namespace Secop.Credit.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceCollections(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionStringsSection = configuration.GetConnectionString(nameof(CreditDbContext));
            services.AddDbContext<CreditDbContext>(options => options.UseNpgsql(connectionStringsSection));
            return services;
        }
    }
}