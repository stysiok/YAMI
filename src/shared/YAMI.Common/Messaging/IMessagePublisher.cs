using YAMI.Common.Messaging.Models;

namespace YAMI.Common.Messaging;

public interface IMessagePublisher
{
    Task PublishAsync<T>(MessagePublishPayload<T> messagePublishPayload) where T : IMessage;
}
