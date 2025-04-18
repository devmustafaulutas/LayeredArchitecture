using MediatR;
using Wolverine;
namespace LayeredArchitecture.Application.Helpers.PingHandler;

public record Ping( string Message): IRequest<Pong> ;