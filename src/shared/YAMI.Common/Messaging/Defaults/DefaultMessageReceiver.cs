using YAMI.Common.Messaging.Models;

namespace YAMI.Common.Messaging.Defaults;

internal sealed class DefaultMessageReceiver : IMessageReceiver
{
    public Task ReceiverAsync<T>(MessageReceivePayload<T> messageReceivePayload) where T : IMessage
        => Task.CompletedTask;
}
