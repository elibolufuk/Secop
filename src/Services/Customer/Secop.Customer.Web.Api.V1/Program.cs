using Secop.Core.Application.Constants;
using Secop.Core.Application.Extensions;
using Secop.Customer.Persistence.DbContexts;
using Secop.Customer.Persistence.Extensions;
using Secop.Customer.Web.Api.V1.Extensions;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddServiceCollections(builder.Configuration);
        builder.Services.AddApplicationServiceCollections(builder.Configuration, ServiceHandlerType.Customer);
        builder.Services.AddMassTransitServices(builder.Configuration);

        var app = builder.Build();

        app.Services.MigrateDatabase<CustomerDbContext>();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}