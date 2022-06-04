using YAMI.Common.Messaging.Models;

namespace YAMI.Common.Messaging;

public interface IMessagePublisher
{
    Task PublishAsync<T>(PublishMessageEnvelope<T> messagePublishPayload) where T : IMessage;
}
