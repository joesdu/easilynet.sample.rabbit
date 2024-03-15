using EasilyNET.RabbitBus.Core;
using EasilyNET.RabbitBus.Core.Attributes;
using EasilyNET.RabbitBus.Core.Enums;

namespace RabbitEvents;

/// <summary>
/// 测试WorkQueues模式消息类型
/// </summary>
[Exchange(EModel.None, queue: "work.queue")]
public class WorkQueuesEvent : Event
{
    /// <summary>
    /// 摘要
    /// </summary>
    public string? Summary { get; set; } = "work_queue";
}