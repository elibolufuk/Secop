using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Secop.Approval.Persistence.DbContexts;
using Secop.Core.Application.Constants;

namespace Secop.Approval.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceCollections(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionStringsSection = configuration.GetConnectionString(nameof(ApprovalDbContext));
            services.AddDbContext<ApprovalDbContext>(options => options.UseNpgsql(connectionStringsSection, x =>
            {
                x.MigrationsHistoryTable(SchemaConstants.MigrationsHistoryTableName, SchemaConstants.Approval);
            }));
            return services;
        }
    }
}