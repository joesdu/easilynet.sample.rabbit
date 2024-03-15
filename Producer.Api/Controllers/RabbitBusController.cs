﻿using EasilyNET.Core.Language;
using EasilyNET.RabbitBus.Core.Abstraction;
using Microsoft.AspNetCore.Mvc;
using RabbitEvents;

namespace Producer.Api.Controllers;

/// <summary>
/// RabbitMQ
/// </summary>
/// <param name="ibus"></param>
[ApiController, Route("api/[controller]/[action]")]
public class RabbitBusController(IBus ibus) : ControllerBase
{
    /// <summary>
    /// 发送HelloWorld消息
    /// </summary>
    [HttpPost]
    public async Task HelloWorld()
    {
        var rand = new Random();
        await ibus.Publish(new HelloWorldEvent(), priority: (byte)rand.Next(0, 9)).ConfigureAwait(false);
    }

    /// <summary>
    /// 发送延时消息,使用延时插件
    /// </summary>
    [HttpPost]
    public async Task Delayed()
    {
        var rand = new Random();
        await ibus.Publish(new DelayedEvent(), priority: (byte)rand.Next(0, 9), ttl: 3000).ConfigureAwait(false);
    }

    /// <summary>
    /// 发送WorkQueues消息
    /// </summary>
    [HttpPost]
    public async Task WorkQueues()
    {
        foreach (var i in ..10)
        {
            await ibus.Publish(new WorkQueuesEvent
            {
                Summary = $"WorkQueuesEvent:{i}"
            }).ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Fanout(发布订阅)发送消息,设置两个队列,所以应该输出两条信息
    /// </summary>
    [HttpPost]
    public async Task Fanout(CancellationToken cancellationToken) => await ibus.Publish(new FanoutEventOne(), cancellationToken: cancellationToken).ConfigureAwait(false);

    /// <summary>
    /// 路由模式(direct)模式发送消息,只向单一主题发送消息
    /// </summary>
    [HttpPost]
    public async Task DirectQueue1(CancellationToken cancellationToken)
    {
        await ibus.Publish(new DirectEventOne(), "direct.queue1", cancellationToken: cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// 路由模式(direct)发送消息,只向单一主题发送消息
    /// </summary>
    [HttpPost]
    public async Task DirectQueue2()
    {
        await ibus.Publish(new DirectEventOne(), "direct.queue2").ConfigureAwait(false);
    }

    /// <summary>
    /// Topic(主题模式)发送消息,向订阅了,[topic.queue.1]主题的队列发送消息.
    /// 只配置了topic.queue.*和topic.queue.1,所以该接口应该只输出两条信息.
    /// </summary>
    [HttpPost]
    public async Task TopicTo1()
    {
        await ibus.Publish(new TopicEventOne(), "topic.queue.1").ConfigureAwait(false);
    }

    /// <summary>
    /// Topic(主题模式)发送消息,向订阅了,[topic.queue.2]主题的队列发送消息.
    /// 只配置了topic.queue.*和topic.queue.1,所以该接口应该只输出一条信息.
    /// </summary>
    [HttpPost]
    public async Task TopicTo2()
    {
        await ibus.Publish(new TopicEventOne(), "topic.queue.2").ConfigureAwait(false);
    }

    /// <summary>
    /// Topic(主题模式)发送消息,向订阅了,[topic.queue.3]主题的队列发送消息.
    /// 只配置了topic.queue.*和topic.queue.1,所以该接口应该只输出一条信息.
    /// </summary>
    [HttpPost]
    public async Task TopicTo3()
    {
        await ibus.Publish(new TopicEventOne(), "topic.queue.3").ConfigureAwait(false);
    }
}