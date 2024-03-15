using EasilyNET.RabbitBus.Core.Abstraction;
using RabbitEvents;
using System.Text.Json;

namespace Consumer.Handlers;

/// <inheritdoc />
public class FanoutEventOneHandler : IEventHandler<FanoutEventOne>
{
    /// <inheritdoc />
    public Task HandleAsync(FanoutEventOne @event)
    {
        Console.WriteLine($"[消息处理自:{nameof(FanoutEventOneHandler)}]-{JsonSerializer.Serialize(@event)}");
        return Task.CompletedTask;
    }
}

/// <inheritdoc />
public class FanoutEventTwoHandler : IEventHandler<FanoutEventTwo>
{
    /// <inheritdoc />
    public Task HandleAsync(FanoutEventTwo @event)
    {
        Console.WriteLine($"[消息处理自:{nameof(FanoutEventTwoHandler)}]-{JsonSerializer.Serialize(@event)}");
        return Task.CompletedTask;
    }
}