using YAMI.Common.Messaging.Models;

namespace YAMI.Common.Messaging.Defaults;

internal sealed class RabbitMQMessagePublisher : IMessagePublisher
{
    public Task PublishAsync<T>(MessagePublishPayload<T> messagePublishPayload) where T : IMessage
        => Task.CompletedTask;
}
