using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Secop.Approval.Persistence.DbContexts;
using Secop.Approval.Persistence.Repositories;
using Secop.Core.Application.Constants;
using Secop.Core.Application.Extensions;
using Secop.Core.Application.Options;
using Secop.Core.Application.Repositories;
using Secop.Core.Application.Repositories.ApprovalRepositories;
using Secop.Core.Domain.Enums;

namespace Secop.Approval.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private const string _databaseSchema = DatabaseSchemaConstants.Approval;

        public static IServiceCollection AddServiceCollections(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationOptions = configuration.GetSection(nameof(ApplicationOptions)).Get<ApplicationOptions>();
            ArgumentNullException.ThrowIfNull(applicationOptions);
            services.AddSingleton(applicationOptions);

            var dataSource = NpgsqlDataSource(configuration);
            services.AddDbContext<ApprovalDbContext>(options =>
            {
                options.UseNpgsql(dataSource, x =>
                {
                    x.MigrationsHistoryTable(DatabaseSchemaConstants.MigrationsHistoryTableName, _databaseSchema);
                });
            });

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ILoanApprovalRepository, LoanApprovalRepository>();
            return services;
        }

        private static NpgsqlDataSource NpgsqlDataSource(IConfiguration configuration)
        {
            var connectionStringsSection = configuration.GetConnectionString(nameof(ApprovalDbContext));
            ArgumentNullException.ThrowIfNull(connectionStringsSection);
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionStringsSection);

            //Enum Mapping
            dataSourceBuilder.MapEnum<CreditRiskLevelType>($"{_databaseSchema}.{EntityConfigurationExtensions.GetEnumDatabaseName<CreditRiskLevelType>()}");
            dataSourceBuilder.MapEnum<ApplicationStatusType>($"{_databaseSchema}.{EntityConfigurationExtensions.GetEnumDatabaseName<ApplicationStatusType>()}");
            dataSourceBuilder.MapEnum<EntityStatusType>($"{_databaseSchema}.{EntityConfigurationExtensions.GetEnumDatabaseName<EntityStatusType>()}");

            return dataSourceBuilder.Build();
        }
    }
}