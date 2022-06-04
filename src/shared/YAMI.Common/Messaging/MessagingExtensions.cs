using Microsoft.Extensions.DependencyInjection;
using YAMI.Common.Messaging.Defaults;
using YAMI.Common.Messaging.RabbitMQ;

namespace YAMI.Common.Messaging;

public static class MessagingExtensions
{
    public static IServiceCollection AddMessaging(this IServiceCollection serviceCollection) => serviceCollection
        .AddSingleton<IMessagePublisher, DefaultMessagePublisher>()
        .AddSingleton<IMessageReceiver, DefaultMessageReceiver>();

    public static IServiceCollection AddRabbitMQ(this IServiceCollection serviceCollection) => serviceCollection
        .AddSingleton<IMessagePublisher, RabbitMQMessagePublisher>()
        .AddSingleton<IMessageReceiver, RabbitMQMessageReceiver>();
}
