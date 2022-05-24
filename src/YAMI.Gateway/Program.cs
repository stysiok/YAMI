using Yarp.ReverseProxy.Transforms;
using YAMI.Common.Colleration;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("yarp"))
    .AddTransforms(builderContext =>
    {
        builderContext.AddRequestTransform(transformContext =>
        {
            transformContext.ProxyRequest.Headers.AddCollerationId(Guid.NewGuid());
            return ValueTask.CompletedTask;
        });
    });

var app = builder.Build();

app.MapReverseProxy();
app.Run();
