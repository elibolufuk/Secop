using MassTransit;
using Secop.Approval.Web.Api.V1.Consumers;
using Secop.Core.Messaging.Constants.V1;
using Secop.Core.ApiCommon.Extensions;

namespace Secop.Approval.Web.Api.V1.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMassTransitServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransitConfigureServices(cfg =>
            {
                cfg.AddConsumer<CreditScoreCreatedEventConsumer>();
                cfg.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(configuration.GetConnectionString("RabbitMqAmqp"));
                    cfg.ReceiveEndpoint(QueueNameConstants.ScoreCreditCreatedQueueName, e =>
                    {
                        e.ConfigureConsumer<CreditScoreCreatedEventConsumer>(context);
                    });
                });
            });
            return services;
        }
    }
}
