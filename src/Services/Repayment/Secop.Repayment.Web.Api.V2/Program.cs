using Secop.Core.Application.Constants;
using System.Reflection;
using Secop.Repayment.Persistence.Extensions;
using Secop.Core.Application.Extensions;
using Secop.Repayment.Web.Api.V2.Extensions;
using Secop.Repayment.Persistence.DbContexts;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddServiceCollections(builder.Configuration);
        builder.Services.AddApplicationServiceCollections(builder.Configuration, ServiceHandlerType.Repayment);
        builder.Services.AddMassTransitServices(builder.Configuration);
        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

        var app = builder.Build();

        app.Services.MigrateDatabase<RepaymentDbContext>();

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