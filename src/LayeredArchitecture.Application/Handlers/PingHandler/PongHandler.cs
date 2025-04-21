using Microsoft.Extensions.Logging;

namespace LayeredArchitecture.Application.Handlers.PingHandler;
public class PongHandler
{
    public void Handle(Pong pong , ILogger<Ping> logger )
    {
        logger.LogInformation("Recived Pong #{}", pong.Number);
    }
}