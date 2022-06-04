using YAMI.Common.Colleration;
using YAMI.Common.Messaging;
using YAMI.Notifier.Events.Receivers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMessaging().AddRabbitMQ().AddHostedService<CryptoBoughtReceiver>();

var app = builder.Build();
app.UseColleration();

app.MapGet("/", () => "Hello World!");

app.Run();
