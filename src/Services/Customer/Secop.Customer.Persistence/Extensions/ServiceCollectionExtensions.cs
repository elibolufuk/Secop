using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Secop.Core.Application.Constants;
using Secop.Core.Application.Extensions;
using Secop.Core.Application.Options;
using Secop.Core.Domain.Enums;
using Secop.Customer.Persistence.DbContexts;

namespace Secop.Customer.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private const string _databaseSchema = DatabaseSchemaConstants.Customer;
        public static IServiceCollection AddServiceCollections(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationOptions = configuration.GetSection(nameof(ApplicationOptions)).Get<ApplicationOptions>();
            ArgumentNullException.ThrowIfNull(applicationOptions);
            services.AddSingleton(applicationOptions);

            var dataSource = NpgsqlDataSource(configuration);
            services.AddDbContext<CustomerDbContext>(options =>
            {
                options.UseNpgsql(dataSource, x =>
                {
                    x.MigrationsHistoryTable(DatabaseSchemaConstants.MigrationsHistoryTableName, _databaseSchema);
                });
            });

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));

            return services;
        }

        private static NpgsqlDataSource NpgsqlDataSource(IConfiguration configuration)
        {
            var connectionStringsSection = configuration.GetConnectionString(nameof(CustomerDbContext));
            ArgumentNullException.ThrowIfNull(connectionStringsSection);
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionStringsSection);

            //Enum Mapping
            dataSourceBuilder.MapEnum<CustomerType>($"{_databaseSchema}.{EntityConfigurationExtensions.GetEnumDatabaseName<CustomerType>()}");
            dataSourceBuilder.MapEnum<EntityStatusType>($"{_databaseSchema}.{EntityConfigurationExtensions.GetEnumDatabaseName<EntityStatusType>()}");

            return dataSourceBuilder.Build();
        }
    }
}