using Microsoft.Extensions.DependencyInjection;
using YAMI.Common.Messaging.Defaults;
using YAMI.Common.Messaging.Pulsar;

namespace YAMI.Common.Messaging;

public static class MessagingExtensions
{
    public static IServiceCollection AddMessaging(this IServiceCollection serviceCollection) => serviceCollection
        .AddSingleton<IMessagePublisher, DefaultMessagePublisher>()
        .AddSingleton<IMessageReceiver, DefaultMessageReceiver>();

    public static IServiceCollection AddPulsar(this IServiceCollection serviceCollection) => serviceCollection
        .AddSingleton<IMessagePublisher, PulsarMessagePublisher>()
        .AddSingleton<IMessageReceiver, PulsarMessageReceiver>();
}
