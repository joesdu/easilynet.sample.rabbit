using EasilyNET.RabbitBus.Core;
using EasilyNET.RabbitBus.Core.Attributes;
using EasilyNET.RabbitBus.Core.Enums;

namespace RabbitEvents;

/// <summary>
/// 测试主题(Topic)模式消息类型
/// </summary>
[Exchange(EModel.Topics, "topic_exchange", "topic.queue.*", "topic_queue1")]
public class TopicEventOne : Event
{
    /// <summary>
    /// 摘要
    /// </summary>
    public string? Summary { get; set; } = "topic_queue1";
}

/// <summary>
/// 测试主题(Topic)模式消息类型
/// </summary>
[Exchange(EModel.Topics, "topic_exchange", "topic.queue.1", "topic_queue2")]
// ReSharper disable once ClassNeverInstantiated.Global
public class TopicEventTwo : Event
{
    /// <summary>
    /// 摘要
    /// </summary>
    public string? Summary { get; set; } = "topic_queue2";
}