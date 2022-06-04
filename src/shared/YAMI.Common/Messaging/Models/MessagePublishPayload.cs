namespace YAMI.Common.Messaging.Models;

public sealed record PublishMessageEnvelope<T>(MessageTopic Topic, T Message) where T : IMessage;
