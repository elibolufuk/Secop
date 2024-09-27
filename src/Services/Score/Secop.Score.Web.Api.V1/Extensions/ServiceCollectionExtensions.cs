using MassTransit;
using Secop.Core.Messaging.Constants.V1;
using Secop.Core.ApiCommon.Extensions;
using Secop.Score.Web.Api.V1.Consumers;

namespace Secop.Score.Web.Api.V1.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMassTransitServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransitConfigureServices(cfg =>
            {
                cfg.AddConsumer<CreditCreatedEventConsumer>();
                cfg.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(configuration.GetConnectionString("RabbitMqAmqp"));
                    cfg.ReceiveEndpoint(QueueNameConstants.CreditApplicationCreatedEventQueueName, e =>
                    {
                        e.ConfigureConsumer<CreditCreatedEventConsumer>(context);
                    });
                });
            });
            return services;
        }
    }
}
