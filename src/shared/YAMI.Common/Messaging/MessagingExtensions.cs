using Microsoft.Extensions.DependencyInjection;
using YAMI.Common.Messaging.Defaults;

namespace YAMI.Common.Messaging;

public static class MessagingExtensions
{
    public static IServiceCollection AddMessaging(this IServiceCollection serviceCollection) => serviceCollection
        .AddSingleton<IMessagePublisher, DefaultMessagePublisher>()
        .AddSingleton<IMessageReceiver, DefaultMessageReceiver>();
}