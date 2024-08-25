using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Secop.Core.Application.Extensions
{
    public static class DbContextExtensions
    {
        public static IServiceProvider MigrateDatabase<T>(this IServiceProvider serviceProvider)
            where T : DbContext
        {
            using var scope = serviceProvider.CreateScope();
            var creditDbContext = scope.ServiceProvider.GetService<T>();
            creditDbContext?.Database.Migrate();
            return serviceProvider;
        }
    }
}