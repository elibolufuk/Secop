using MassTransit;
using Secop.Core.ApiCommon.Constants;
using Secop.Core.ApiCommon.Extensions;
using Secop.Credit.Web.Api.Consumers;

namespace Secop.Credit.Web.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMassTransitServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransitConfigureServices(cfg =>
            {
                cfg.AddConsumer<CreditScoreNotCreatedEventConsumer>();
                cfg.AddConsumer<LoanApprovalNotCreatedEventConsumer>();
                cfg.AddConsumer<LoanApprovalCreatedEventConsumer>();
                cfg.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(configuration.GetConnectionString("RabbitMqAmqp"));

                    cfg.ReceiveEndpoint(QueueNameConstants.ScoreCreditNotCreatedEventQueueName, e
                        => e.ConfigureConsumer<CreditScoreNotCreatedEventConsumer>(context));
                    cfg.ReceiveEndpoint(QueueNameConstants.LoanApprovalNotCreatedEventQueueName, e
                        => e.ConfigureConsumer<LoanApprovalNotCreatedEventConsumer>(context));
                    cfg.ReceiveEndpoint(QueueNameConstants.LoanApprovalCreatedEventQueueName, e
                        => e.ConfigureConsumer<LoanApprovalCreatedEventConsumer>(context));
                });
            });
            return services;
        }
    }
}