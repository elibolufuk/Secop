using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Secop.Core.ApiCommon.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMassTransitConfigureServices(this IServiceCollection services, Action<IBusRegistrationConfigurator> configurator)
        {
            services.AddMassTransit(cfg =>
            {
                configurator(cfg);
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