using Secop.Approval.Persistence.DbContexts;
using Secop.Approval.Persistence.Extensions;
using Secop.Approval.Web.Api.Extensions;
using Secop.Core.Application.Constants;
using Secop.Core.Application.Extensions;
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
        builder.Services.AddApplicationServiceCollections(builder.Configuration, ServiceHandlerType.Approval);
        builder.Services.AddMassTransitServices(builder.Configuration);
        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

        var app = builder.Build();

        app.Services.MigrateDatabase<ApprovalDbContext>();

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