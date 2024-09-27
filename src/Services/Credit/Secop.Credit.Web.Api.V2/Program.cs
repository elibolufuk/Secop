using Secop.Core.Application.Constants;
using System.Reflection;
using Secop.Credit.Persistence.Extensions;
using Secop.Core.Application.Extensions;
using Secop.Credit.Web.Api.V2.Extensions;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddServiceCollections(builder.Configuration);
        builder.Services.AddApplicationServiceCollections(builder.Configuration, ServiceHandlerType.Credit);
        builder.Services.AddMassTransitServices(builder.Configuration);
        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
        var app = builder.Build();

        // Configure the HTTP request pipeline.
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