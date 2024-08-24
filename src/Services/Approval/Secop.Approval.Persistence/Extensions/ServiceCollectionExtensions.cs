using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Secop.Approval.Persistence.DbContexts;

namespace Secop.Approval.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceCollections(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionStringsSection = configuration.GetConnectionString(nameof(ApprovalDbContext));
            services.AddDbContext<ApprovalDbContext>(options => options.UseNpgsql(connectionStringsSection));
            return services;
        }
    }
}