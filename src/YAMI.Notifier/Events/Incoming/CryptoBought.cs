using YAMI.Common.Messaging.Models;

namespace YAMI.Notifier.Events.Incoming;

internal sealed record CryptoBought(string Name, int Amount) : IMessage;
