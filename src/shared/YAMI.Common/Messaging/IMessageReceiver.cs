using YAMI.Common.Messaging.Models;

namespace YAMI.Common.Messaging;

public interface IMessageReceiver
{
    Task ReceiverAsync<T>(ReceivedMessageEnvelope<T> messageReceivePayload) where T : IMessage;
}
