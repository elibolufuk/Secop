using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOcelot();
builder.Configuration.AddJsonFile("ocelot.json", false, true);

var app = builder.Build();

app.UseRouting();

#pragma warning disable ASP0014 // Suggest using top level route registrations
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("Api Gateway");
    });
});
#pragma warning restore ASP0014 // Suggest using top level route registrations

await app.UseOcelot();
app.Run();