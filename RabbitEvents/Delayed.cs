using EasilyNET.Core.BaseType;
using EasilyNET.RabbitBus.Core.Abstraction;
using EasilyNET.RabbitBus.Core.Attributes;
using EasilyNET.RabbitBus.Core.Enums;

namespace RabbitEvents;

/// <summary>
/// 测试Delayed模式消息类型
/// </summary>
[Exchange(EModel.Delayed, "xdl.hello", queue: "xdl.hello.world", isDlx: true), QueueArg("x-message-ttl", 5000)]
public class DelayedEvent : IEvent
{
    /// <summary>
    /// 摘要
    /// </summary>
    public string Summary { get; set; } = "delayed_msg";

    /// <summary>
    /// 消息ID
    /// </summary>
    public string EventId => SnowId.GenerateNewId().ToString();
}