using MassTransit;
using Secop.Approval.Web.Api.Consumers;
using Secop.Core.ApiCommon.Constants;
using Secop.Core.ApiCommon.Extensions;

namespace Secop.Approval.Web.Api.Extensions
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
