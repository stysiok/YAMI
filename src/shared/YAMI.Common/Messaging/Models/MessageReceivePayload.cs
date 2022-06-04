namespace YAMI.Common.Messaging.Models;

public sealed record ReceivedMessageEnvelope<T>(MessageTopic Topic, Func<T, Task> Handler) where T : IMessage;
