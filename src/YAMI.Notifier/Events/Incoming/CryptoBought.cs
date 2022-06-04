
namespace YAMI.Notifier.Events.Incoming;

internal sealed record CryptoBought(string Name, int Amount) : YAMI.Common.Messaging.Models.IMessage;
