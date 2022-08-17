using YAMI.Common.Messaging;
using YAMI.Notifier.Events.Incoming;
using YAMI.Common.Messaging.Models;

namespace YAMI.Notifier.Events.Receivers;

internal sealed class CryptoBoughtReceiver : BackgroundService
{
    private readonly IMessageReceiver _messageReceiver;
    private readonly ILogger<CryptoBoughtReceiver> _logger;

    public CryptoBoughtReceiver(IMessageReceiver messageReceiver,
        ILogger<CryptoBoughtReceiver> logger)
    {
        _messageReceiver = messageReceiver;
        _logger = logger;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _messageReceiver.ReceiverAsync(new ReceivedMessageEnvelope<CryptoBought>(MessageTopic.Orders, @event =>
        {
            // _logger.LogInformation($"Message {@event.Name} : {@event.Amount}");
            return Task.CompletedTask;
        }));

        return Task.CompletedTask;
    }
}
