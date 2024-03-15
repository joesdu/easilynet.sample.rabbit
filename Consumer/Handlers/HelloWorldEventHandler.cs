using EasilyNET.RabbitBus.Core.Abstraction;
using RabbitEvents;
using System.Text.Json;

namespace Consumer.Handlers;

public class HelloWorldEventHandler : IEventHandler<HelloWorldEvent>
{
    /// <inheritdoc />
    public Task HandleAsync(HelloWorldEvent @event)
    {
        Console.WriteLine($"[消息处理自:{nameof(HelloWorldEventHandler)}]-{JsonSerializer.Serialize(@event)}");
        return Task.CompletedTask;
    }
}