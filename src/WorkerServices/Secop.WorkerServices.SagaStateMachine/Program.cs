using Secop.WorkerServices.SagaStateMachine;
using Secop.WorkerServices.SagaStateMachine.Extensions;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        builder.Services.AddMassTransitServices(builder.Configuration);
        builder.Services.AddHostedService<Worker>();

        var host = builder.Build();
        host.Run();
    }
}