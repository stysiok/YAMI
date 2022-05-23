namespace YAMI.Common.Messaging.Models;

public sealed record MessagePublishPayload<T>(MessageTopic Topic, T message) where T : IMessage;
