using YAMI.Common.Messaging.Models;

namespace YAMI.Common.Messaging;

public interface IMessageReceiver
{
    Task ReceiverAsync<T>(MessageReceivePayload<T> messageReceivePayload) where T : IMessage;
}