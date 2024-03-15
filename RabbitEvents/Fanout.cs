using EasilyNET.RabbitBus.Core;
using EasilyNET.RabbitBus.Core.Attributes;
using EasilyNET.RabbitBus.Core.Enums;

namespace RabbitEvents;

/// <summary>
/// 测试发布/订阅(Publish)模式消息类型
/// </summary>
[Exchange(EModel.PublishSubscribe, "fanout_exchange", queue: "fanout_queue1")]
public class FanoutEventOne : Event
{
    /// <summary>
    /// 摘要
    /// </summary>
    public string? Summary { get; set; } = "fanout_queue1";
}

/// <summary>
/// 测试发布/订阅(Publish)模式消息类型
/// </summary>
[Exchange(EModel.PublishSubscribe, "fanout_exchange", queue: "fanout_queue2")]
// ReSharper disable once ClassNeverInstantiated.Global
public class FanoutEventTwo : Event
{
    /// <summary>
    /// 摘要
    /// </summary>
    public string? Summary { get; set; } = "fanout_queue2";
}