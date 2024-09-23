using Secop.Core.Application.Constants;
using Secop.Core.Application.Extensions;
using Secop.Score.Persistence.DbContexts;
using Secop.Score.Persistence.Extensions;
using Secop.Score.Web.Api.V1.Extensions;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddServiceCollections(builder.Configuration);
        builder.Services.AddApplicationServiceCollections(builder.Configuration, ServiceHandlerType.Score);
        builder.Services.AddMassTransitServices(builder.Configuration);
        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

        var app = builder.Build();

        app.Services.MigrateDatabase<ScoreDbContext>();

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