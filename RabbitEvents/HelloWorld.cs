using EasilyNET.Core.BaseType;
using EasilyNET.RabbitBus.Core.Abstraction;
using EasilyNET.RabbitBus.Core.Attributes;
using EasilyNET.RabbitBus.Core.Enums;

namespace RabbitEvents;

/// <summary>
/// 测试HelloWorld模式消息类型
/// </summary>
[Exchange(EModel.None, queue: "hello.world")]
public class HelloWorldEvent : IEvent
{
    /// <summary>
    /// 摘要
    /// </summary>
    public string Summary { get; set; } = "hello_world";

    /// <summary>
    /// 消息ID
    /// </summary>
    public string EventId => SnowId.GenerateNewId().ToString();
}