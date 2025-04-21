namespace LayeredArchitecture.Application.Handlers.PingHandler;

// public record Ping(
//     string Message
// );

public class Ping
{
    private string v;

    public Ping(string v)
    {
        this.v = v;
    }

    public int Number { get; set; }
    
}