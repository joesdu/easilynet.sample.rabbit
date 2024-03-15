Console.Title = "❤️ Producer.Api";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
// 配置服务(亦可使用集群模式或者使用配置文件)
builder.Services.AddRabbitBus(c =>
{
    c.Host = "localhost";
    c.Port = 5672;
    c.UserName = "guest";
    c.PassWord = "guest";
});
// 或者使用配置文件
// builder.Services.AddRabbitBus(builder.Configuration, poolCount: (uint)Environment.ProcessorCount);

// 对Swagger添加文档支持,为了方便,这里引入我的宁一个库
const string version = "v1";
const string title = "Producer.Api";
const string name = $"{title}-{version}";
builder.Services.AddSwaggerGen(c =>
{
    // 配置默认的文档信息
    c.SwaggerDoc(name, new()
    {
        Title = title,
        Version = version,
        Description = "Console.WriteLine(\"🐂🍺\")"
    });
    // 这里使用EasilyNET提供的扩展配置.
    c.EasilySwaggerGenOptions(name);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) _ = app.UseDeveloperExceptionPage();
// 注册 Swagger 中间件
app.UseSwagger().UseSwaggerUI(c =>
{
    // 配置默认文档
    c.SwaggerEndpoint($"/swagger/{name}/swagger.json", $"{title} {version}");
    // 使用EasilyNET提供的扩展配置
    c.EasilySwaggerUIOptions();
});
app.UseHttpsRedirection();
app.MapControllers();
app.Run();