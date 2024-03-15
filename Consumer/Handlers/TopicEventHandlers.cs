using EasilyNET.RabbitBus.Core.Abstraction;
using RabbitEvents;
using System.Text.Json;

namespace Consumer.Handlers;

/// <inheritdoc />
public class TopicEventOneHandler : IEventHandler<TopicEventOne>
{
    /// <inheritdoc />
    public Task HandleAsync(TopicEventOne @event)
    {
        Console.WriteLine($"[消息处理自:{nameof(TopicEventOneHandler)}]-{JsonSerializer.Serialize(@event)}");
        return Task.CompletedTask;
    }
}

/// <inheritdoc />
public class TopicEventTwoHandler : IEventHandler<TopicEventTwo>
{
    /// <inheritdoc />
    public Task HandleAsync(TopicEventTwo @event)
    {
        Console.WriteLine($"[消息处理自:{nameof(TopicEventTwoHandler)}]-{JsonSerializer.Serialize(@event)}");
        return Task.CompletedTask;
    }
}