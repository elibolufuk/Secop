using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Secop.Core.Application.Constants;
using Secop.Core.Application.Extensions;
using Secop.Core.Application.Features.Credit;
using Secop.Core.Application.Repositories;
using Secop.Core.Application.Repositories.CreditRepositories;
using Secop.Core.Domain.Enums;
using Secop.Credit.Persistence.DbContexts;
using Secop.Credit.Persistence.Repositories;
using System.Reflection;

namespace Secop.Credit.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private const string SchemaDefault = SchemaConstants.Credit;

        public static IServiceCollection AddServiceCollections(this IServiceCollection services, IConfiguration configuration)
        {
            var dataSource = NpgsqlDataSource(configuration);
            services.AddDbContext<CreditDbContext>(options =>
            {
                options.UseNpgsql(dataSource, x =>
                {
                    x.MigrationsHistoryTable(SchemaConstants.MigrationsHistoryTableName, SchemaDefault);
                });
            });

            services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(CreditAssembly).Assembly));

            services.AddScoped(typeof(IGenericRepository<>), typeof(PostgreGenericRepository<>));
            services.AddScoped<ICreditApplicationRepository, CreditApplicationRepository>();

            return services;
        }

        private static NpgsqlDataSource NpgsqlDataSource(IConfiguration configuration)
        {
            var connectionStringsSection = configuration.GetConnectionString(nameof(CreditDbContext));
            ArgumentNullException.ThrowIfNull(connectionStringsSection);
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionStringsSection);

            dataSourceBuilder.MapEnum<CreditType>($"{SchemaDefault}.{EntityConfigurationExtensions.GetEnumDatabaseName<CreditType>()}");
            dataSourceBuilder.MapEnum<EntityStatusType>($"{SchemaDefault}.{EntityConfigurationExtensions.GetEnumDatabaseName<EntityStatusType>()}");

            return dataSourceBuilder.Build();
        }
    }
}