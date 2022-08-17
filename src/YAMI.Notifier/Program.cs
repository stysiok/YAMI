using YAMI.Common.Colleration;
using YAMI.Common.Messaging;
using YAMI.Notifier.Events.Receivers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMessaging().AddPulsar().AddHostedService<CryptoBoughtReceiver>();

var app = builder.Build();
app.UseColleration();

app.MapGet("/", () => "Hello World!");

app.Run();
