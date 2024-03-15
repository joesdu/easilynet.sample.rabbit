using EasilyNET.RabbitBus.Core.Abstraction;
using RabbitEvents;
using System.Text.Json;

namespace Consumer.Handlers;

public class WorkQueuesEventOneHandler : IEventHandler<WorkQueuesEvent>
{
    /// <inheritdoc />
    public Task HandleAsync(WorkQueuesEvent @event)
    {
        Console.WriteLine($"[消息处理自:{nameof(WorkQueuesEventOneHandler)}]-{JsonSerializer.Serialize(@event)}");
        return Task.CompletedTask;
    }
}