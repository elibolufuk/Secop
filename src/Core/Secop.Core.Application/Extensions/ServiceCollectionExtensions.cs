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
        public static IServiceCollection AddApplicationServiceCollections(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }

        public static IServiceCollection AddMediatRWithFiltering(this IServiceCollection services, ServiceHandlerType serviceType)
        {
            var assemblies = new List<Assembly>();
            var assembly = Assembly.GetExecutingAssembly();

            var handlerTypes = assembly.GetTypes()
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)))
                .Where(t => t.GetCustomAttributes<ServiceHandlerAttribute>().Any(attr => attr.ServiceType == serviceType))
                .Distinct();

            foreach (var handlerType in handlerTypes)
            {
                var interfaces = handlerType.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>))
                    .ToList();

                foreach (var @interface in interfaces)
                {
                    services.AddTransient(@interface, handlerType);
                }
            }

            return services;
        }

    }
}
