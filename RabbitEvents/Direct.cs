using EasilyNET.RabbitBus.Core;
using EasilyNET.RabbitBus.Core.Attributes;
using EasilyNET.RabbitBus.Core.Enums;

namespace RabbitEvents;

/// <summary>
/// 测试路由(Routing)模式消息类型
/// </summary>
[Exchange(EModel.Routing, "direct_exchange", "direct.queue1", "direct_queue1")]
public class DirectEventOne : Event
{
    /// <summary>
    /// 摘要
    /// </summary>
    public string? Summary { get; set; } = "direct_queue1";
}

/// <summary>
/// 测试路由(Routing)模式消息类型
/// </summary>
[Exchange(EModel.Routing, "direct_exchange", "direct.queue2", "direct_queue2")]
// ReSharper disable once ClassNeverInstantiated.Global
public class DirectEventTwo : Event
{
    /// <summary>
    /// 摘要
    /// </summary>
    public string? Summary { get; set; } = "direct_queue2";
}