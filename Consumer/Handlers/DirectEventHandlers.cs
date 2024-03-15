using EasilyNET.RabbitBus.Core.Abstraction;
using RabbitEvents;
using System.Text.Json;

namespace Consumer.Handlers;

/// <inheritdoc />
public class DirectEventOneHandler : IEventHandler<DirectEventOne>
{
    /// <inheritdoc />
    public Task HandleAsync(DirectEventOne @event)
    {
        Console.WriteLine($"[消息处理自:{nameof(DirectEventOneHandler)}]-{JsonSerializer.Serialize(@event)}");
        return Task.CompletedTask;
    }
}

/// <inheritdoc />
public class DirectEventTwoHandler : IEventHandler<DirectEventTwo>
{
    /// <inheritdoc />
    public Task HandleAsync(DirectEventTwo @event)
    {
        Console.WriteLine($"[消息处理自:{nameof(DirectEventTwoHandler)}]-{JsonSerializer.Serialize(@event)}");
        return Task.CompletedTask;
    }
}