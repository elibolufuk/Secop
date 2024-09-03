using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Secop.Core.Application.Constants;
using Secop.Core.Application.Extensions;
using Secop.Core.Domain.Enums;
using Secop.Customer.Persistence.DbContexts;

namespace Secop.Customer.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private const string SchemaDefault = DatabaseSchemaConstants.Customer;

        public static IServiceCollection AddServiceCollections(this IServiceCollection services, IConfiguration configuration)
        {
            var dataSource = NpgsqlDataSource(configuration);
            services.AddDbContext<CustomerDbContext>(options =>
            {
                options.UseNpgsql(dataSource, x =>
                {
                    x.MigrationsHistoryTable(DatabaseSchemaConstants.MigrationsHistoryTableName, SchemaDefault);
                });
            });

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));
            services.AddMediatRWithFiltering(ServiceHandlerType.Customer);

            return services;
        }

        private static NpgsqlDataSource NpgsqlDataSource(IConfiguration configuration)
        {
            var connectionStringsSection = configuration.GetConnectionString(nameof(CustomerDbContext));
            ArgumentNullException.ThrowIfNull(connectionStringsSection);
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionStringsSection);

            //Enum Mapping
            dataSourceBuilder.MapEnum<CustomerType>($"{SchemaDefault}.{EntityConfigurationExtensions.GetEnumDatabaseName<CustomerType>()}");
            dataSourceBuilder.MapEnum<EntityStatusType>($"{SchemaDefault}.{EntityConfigurationExtensions.GetEnumDatabaseName<EntityStatusType>()}");

            return dataSourceBuilder.Build();
        }
    }
}