using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Secop.Approval.Persistence.DbContexts;
using Secop.Approval.Persistence.Repositories;
using Secop.Core.Application.Constants;
using Secop.Core.Application.Extensions;
using Secop.Core.Application.Repositories;
using Secop.Core.Application.Repositories.ApprovalRepositories;
using Secop.Core.Domain.Enums;

namespace Secop.Approval.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private const string SchemaDefault = DatabaseSchemaConstants.Approval;

        public static IServiceCollection AddServiceCollections(this IServiceCollection services, IConfiguration configuration)
        {
            var dataSource = NpgsqlDataSource(configuration);
            services.AddDbContext<ApprovalDbContext>(options =>
            {
                options.UseNpgsql(dataSource, x =>
                {
                    x.MigrationsHistoryTable(DatabaseSchemaConstants.MigrationsHistoryTableName, SchemaDefault);
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
            dataSourceBuilder.MapEnum<CreditRiskLevelType>($"{SchemaDefault}.{EntityConfigurationExtensions.GetEnumDatabaseName<CreditRiskLevelType>()}");
            dataSourceBuilder.MapEnum<ApplicationStatusType>($"{SchemaDefault}.{EntityConfigurationExtensions.GetEnumDatabaseName<ApplicationStatusType>()}");
            dataSourceBuilder.MapEnum<EntityStatusType>($"{SchemaDefault}.{EntityConfigurationExtensions.GetEnumDatabaseName<EntityStatusType>()}");

            return dataSourceBuilder.Build();
        }
    }
}