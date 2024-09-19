using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Secop.Core.Application.Attributes;
using Secop.Core.Application.Constants;
using System.Reflection;

namespace Secop.Core.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServiceCollections(this IServiceCollection services, IConfiguration configuration, ServiceHandlerType serviceType)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatRWithFiltering(serviceType);
            return services;
        }

        private static IServiceCollection AddMediatRWithFiltering(this IServiceCollection services, ServiceHandlerType serviceType)
        {
            var assemblies = new List<Assembly>();
            var assembly = Assembly.GetExecutingAssembly();

            var handlerTypes = assembly.GetTypes()
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)))
                .Where(t => t.GetCustomAttributes<ServiceHandlerAttribute>().Any(attr => attr.ServiceType == serviceType))
                .Distinct();

            handlerTypes?.ToList()
                .ForEach(handlerType =>
            {
                var interfaces = handlerType.GetInterfaces();
                interfaces?.ToList()
                .ForEach(@interface =>
                {
                    services.AddTransient(@interface, handlerType);
                });
            });

            return services;
        }
    }
}
