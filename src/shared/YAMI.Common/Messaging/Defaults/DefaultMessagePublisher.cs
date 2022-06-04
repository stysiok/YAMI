using YAMI.Common.Messaging.Models;

namespace YAMI.Common.Messaging.Defaults;

internal sealed class DefaultMessagePublisher : IMessagePublisher
{
    public Task PublishAsync<T>(PublishMessageEnvelope<T> messagePublishPayload) where T : IMessage
        => Task.CompletedTask;
}
