using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

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

        public static EntityTypeBuilder<TEntity> SeedData<TEntity>(this EntityTypeBuilder<TEntity> builder, string? jsonPath = null)
            where TEntity : class
        {
            var jsonFile = jsonPath ?? string.Format("SeedDataJson/{0}.json", typeof(TEntity).Name);

            if (File.Exists(jsonFile))
            {
                using StreamReader sr = new(jsonFile);
                var json = sr.ReadToEnd();
                if (json != null)
                {
                    var data = JsonConvert.DeserializeObject<List<TEntity>>(json);
                    if (data != null)
                    {
                        foreach (var item in data)
                            foreach (var property in typeof(TEntity).GetProperties())
                                if (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?))
                                {
                                    var value = (DateTime?)property.GetValue(item);
                                    if (value.HasValue && value.Value.Kind == DateTimeKind.Unspecified)
                                        property.SetValue(item, DateTime.SpecifyKind(value.Value, DateTimeKind.Utc));
                                }
                        builder.HasData(data);
                    }
                }
            }
            return builder;
        }
    }
}