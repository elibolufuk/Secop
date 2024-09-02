using Secop.Core.ApiCommon.Extensions;
using Secop.Core.Application.Extensions;
using Secop.Score.Persistence.DbContexts;
using Secop.Score.Persistence.Extensions;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddServiceCollections(builder.Configuration);
        builder.Services.AddApplicationServiceCollections(builder.Configuration);
        builder.Services.AddMassTransitServices(builder.Configuration);

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