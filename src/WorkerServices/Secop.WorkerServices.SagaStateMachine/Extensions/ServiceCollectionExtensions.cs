using MassTransit;
using SagaStateMachine.Models;
using Secop.Core.Messaging.Constants.V2;
using Secop.WorkerServices.SagaStateMachine.Models;
using Secop.WorkerServices.SagaStateMachine.Options;

namespace Secop.WorkerServices.SagaStateMachine.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMassTransitServices(this IServiceCollection services, IConfiguration configuration)
        {
            var sagaStateMachineOptions = configuration.GetSection(nameof(SagaStateMachineOptions)).Get<SagaStateMachineOptions>();
            ArgumentNullException.ThrowIfNull(sagaStateMachineOptions);
            services.AddSingleton(sagaStateMachineOptions);

            services.AddMassTransit(cfg =>
            {
                cfg.AddSagaStateMachine<CreditApplicationStateMachine, CreditApplicationStateInstance>()
                .MongoDbRepository(r =>
                {
                    r.Connection = configuration.GetConnectionString("MongoDb");
                    r.DatabaseName = sagaStateMachineOptions.DatabaseName;
                    r.CollectionName = sagaStateMachineOptions.CollectionName;
                });

                cfg.UsingRabbitMq((context, configure) =>
                {
                    configure.Host(configuration.GetConnectionString("RabbitMqAmqp"));

                    configure.ReceiveEndpoint(QueueNameConstants.CreditApplicationSaga, e =>
                    {
                        e.ConfigureSaga<CreditApplicationStateInstance>(context);
                    });
                });
            });

            services.Configure<MassTransitHostOptions>(options =>
            {
                options.WaitUntilStarted = true;
                options.StartTimeout = TimeSpan.FromSeconds(30);
                options.StopTimeout = TimeSpan.FromMinutes(1);
            });

            return services;
        }
    }
}