using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Secop.Core.Application.Constants;
using Secop.Core.Application.Options;
using Secop.Core.Application.Repositories;
using Secop.Repayment.Persistence.DbContexts;
using Secop.Repayment.Persistence.Repositories;

namespace Secop.Repayment.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private const string _databaseSchema = DatabaseSchemaConstants.Repayment;

        public static IServiceCollection AddServiceCollections(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationOptions = configuration.GetSection(nameof(ApplicationOptions)).Get<ApplicationOptions>();
            ArgumentNullException.ThrowIfNull(applicationOptions);
            services.AddSingleton(applicationOptions);

            var dataSource = NpgsqlDataSource(configuration);
            services.AddDbContext<RepaymentDbContext>(options =>
            {
                options.UseNpgsql(dataSource, x =>
                {
                    x.MigrationsHistoryTable(DatabaseSchemaConstants.MigrationsHistoryTableName, _databaseSchema);
                });
            });

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }

        private static NpgsqlDataSource NpgsqlDataSource(IConfiguration configuration)
        {
            var connectionStringsSection = configuration.GetConnectionString(nameof(RepaymentDbContext));
            ArgumentNullException.ThrowIfNull(connectionStringsSection);
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionStringsSection);

            return dataSourceBuilder.Build();
        }
    }
}