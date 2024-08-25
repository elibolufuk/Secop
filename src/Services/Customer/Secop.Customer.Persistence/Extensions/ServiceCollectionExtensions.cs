﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Secop.Core.Application.Constants;
using Secop.Customer.Persistence.DbContexts;

namespace Secop.Customer.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceCollections(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionStringsSection = configuration.GetConnectionString(nameof(CustomerDbContext));
            services.AddDbContext<CustomerDbContext>(options => options.UseNpgsql(connectionStringsSection, x =>
            {
                x.MigrationsHistoryTable(SchemaConstants.MigrationsHistoryTableName, SchemaConstants.Customer);
            }));
            return services;
        }
    }
}