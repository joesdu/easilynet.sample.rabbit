using EasilyNET.RabbitBus.Core.Abstraction;
using RabbitEvents;
using System.Text.Json;

namespace Consumer.Handlers;

public class DelayedEventHandler : IEventHandler<DelayedEvent>
{
    /// <inheritdoc />
    public Task HandleAsync(DelayedEvent @event)
    {
        Console.WriteLine($"[消息处理自:{nameof(DelayedEventHandler)}]-{JsonSerializer.Serialize(@event)}");
        return Task.CompletedTask;
    }
}