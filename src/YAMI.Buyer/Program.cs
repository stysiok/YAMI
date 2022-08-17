using YAMI.Buyer.Events.Outgoing;
using YAMI.Common.Colleration;
using YAMI.Common.Logging;
using YAMI.Common.Messaging;
using YAMI.Common.Messaging.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseLogging();

builder.Services.AddMessaging().AddPulsar();

var app = builder.Build();
app.UseColleration();

app.MapGet("/", (HttpContext httpContext, IServiceProvider serviceProvider) =>
{
    var collerationId = httpContext.GetCollerationId();
    var p = serviceProvider.GetRequiredService<IMessagePublisher>();

    p.PublishAsync(new PublishMessageEnvelope<CryptoBought>(MessageTopic.Orders, new CryptoBought(collerationId, 1)));
});

app.Run();
