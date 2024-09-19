using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Secop.Core.Application.Constants;
using Secop.Core.Application.Extensions;
using Secop.Core.Application.Repositories;
using Secop.Core.Application.Repositories.ScoreRepositories;
using Secop.Core.Domain.Enums;
using Secop.Credit.Persistence.Repositories;
using Secop.Score.Persistence.DbContexts;
using Secop.Score.Persistence.Repositories;

namespace Secop.Score.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private const string SchemaDefault = DatabaseSchemaConstants.Score;

        public static IServiceCollection AddServiceCollections(this IServiceCollection services, IConfiguration configuration)
        {
            var dataSource = NpgsqlDataSource(configuration);
            services.AddDbContext<ScoreDbContext>(options =>
            {
                options.UseNpgsql(dataSource, x =>
                {
                    x.MigrationsHistoryTable(DatabaseSchemaConstants.MigrationsHistoryTableName, SchemaDefault);
                });
            });

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICreditScoreRepository, CreditScoreRepository>();
            services.AddScoped<IRiskLevelRangeRepository, RiskLevelRangeRepository>();
            return services;
        }

        private static NpgsqlDataSource NpgsqlDataSource(IConfiguration configuration)
        {
            var connectionStringsSection = configuration.GetConnectionString(nameof(ScoreDbContext));
            ArgumentNullException.ThrowIfNull(connectionStringsSection);
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionStringsSection);

            //Enum Mapping
            dataSourceBuilder.MapEnum<CreditRiskLevelType>($"{SchemaDefault}.{EntityConfigurationExtensions.GetEnumDatabaseName<CreditRiskLevelType>()}");
            dataSourceBuilder.MapEnum<EntityStatusType>($"{SchemaDefault}.{EntityConfigurationExtensions.GetEnumDatabaseName<EntityStatusType>()}");

            return dataSourceBuilder.Build();
        }
    }
}