using MassTransit;
using Secop.Core.ApiCommon.Extensions;

namespace Secop.Customer.Web.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMassTransitServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransitConfigureServices(cfg =>
            {
                cfg.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(configuration.GetConnectionString("RabbitMqAmqp"));
                });
            });
            return services;
        }
    }
}
