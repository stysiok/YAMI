namespace YAMI.Common.Messaging.Models;

public sealed record MessageReceivePayload<T>(MessageTopic Topic, Action<T> handler) where T : IMessage;