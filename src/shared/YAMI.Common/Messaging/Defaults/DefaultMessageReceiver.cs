using YAMI.Common.Messaging.Models;

namespace YAMI.Common.Messaging.Defaults;

internal sealed class DefaultMessageReceiver : IMessageReceiver
{
    public Task ReceiverAsync<T>(ReceivedMessageEnvelope<T> messageReceivePayload) where T : IMessage
        => Task.CompletedTask;
}
