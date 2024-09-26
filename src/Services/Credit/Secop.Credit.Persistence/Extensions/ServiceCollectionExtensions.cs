using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Secop.Core.Application.Constants;
using Secop.Core.Application.Extensions;
using Secop.Core.Application.Repositories;
using Secop.Core.Application.Repositories.CreditRepositories;
using Secop.Core.Domain.Enums;
using Secop.Credit.Persistence.DbContexts;
using Secop.Credit.Persistence.Repositories;
using Secop.Core.Application.Options;

namespace Secop.Credit.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private const string _databaseSchema = DatabaseSchemaConstants.Credit;
        public static IServiceCollection AddServiceCollections(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationOptions = configuration.GetSection(nameof(ApplicationOptions)).Get<ApplicationOptions>();
            ArgumentNullException.ThrowIfNull(applicationOptions);
            services.AddSingleton(applicationOptions);

            var dataSource = NpgsqlDataSource(configuration);
            services.AddDbContext<CreditDbContext>(options =>
            {
                options.UseNpgsql(dataSource, x =>
                {
                    x.MigrationsHistoryTable(DatabaseSchemaConstants.MigrationsHistoryTableName, _databaseSchema);
                });
            });

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICreditApplicationRepository, CreditApplicationRepository>();

            return services;
        }

        private static NpgsqlDataSource NpgsqlDataSource(IConfiguration configuration)
        {
            var connectionStringsSection = configuration.GetConnectionString(nameof(CreditDbContext));
            ArgumentNullException.ThrowIfNull(connectionStringsSection);
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionStringsSection);

            dataSourceBuilder.MapEnum<CreditType>($"{_databaseSchema}.{EntityConfigurationExtensions.GetEnumDatabaseName<CreditType>()}");
            dataSourceBuilder.MapEnum<CreditRiskLevelType>($"{_databaseSchema}.{EntityConfigurationExtensions.GetEnumDatabaseName<CreditRiskLevelType>()}");
            dataSourceBuilder.MapEnum<ApplicationStatusType>($"{_databaseSchema}.{EntityConfigurationExtensions.GetEnumDatabaseName<ApplicationStatusType>()}");
            dataSourceBuilder.MapEnum<EntityStatusType>($"{_databaseSchema}.{EntityConfigurationExtensions.GetEnumDatabaseName<EntityStatusType>()}");

            return dataSourceBuilder.Build();
        }
    }
}