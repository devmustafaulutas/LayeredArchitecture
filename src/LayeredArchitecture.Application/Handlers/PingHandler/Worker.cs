using LayeredArchitecture.Application.Handlers.PingHandler;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Wolverine;

public class PingWorker : BackgroundService
{
    private readonly IServiceProvider _provider;

    public PingWorker(IServiceProvider provider)
    {
        _provider = provider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = _provider.CreateScope();
        var bus = scope.ServiceProvider.GetRequiredService<IMessageBus>();

        while (!stoppingToken.IsCancellationRequested)
        {
            var response = await bus.InvokeAsync<Pong>(
                new Ping("Worker !!!!!")
            );
            Console.WriteLine(response.Number);
            await Task.Delay(5000, stoppingToken);
        }
    }
}
