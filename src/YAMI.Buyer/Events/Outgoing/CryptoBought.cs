using YAMI.Common.Messaging.Models;

namespace YAMI.Buyer.Events.Outgoing;

internal sealed record CryptoBought(string Name, int Amount) : IMessage;
