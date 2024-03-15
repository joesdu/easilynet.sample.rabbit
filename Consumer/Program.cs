Console.Title = "❤️ Consumer";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container

// 配置服务(亦可使用集群模式或者使用配置文件)
builder.Services.AddRabbitBus(c =>
{
    c.Host = "localhost";
    c.Port = 5672;
    c.UserName = "guest";
    c.PassWord = "guest";
});
var app = builder.Build();
app.Run();