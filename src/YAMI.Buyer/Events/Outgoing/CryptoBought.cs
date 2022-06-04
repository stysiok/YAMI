namespace YAMI.Buyer.Events.Outgoing;

internal sealed record CryptoBought(string Name, int Amount) : Common.Messaging.Models.IMessage;
