using YAMI.Common.Messaging;
using YAMI.Notifier.Events.Incoming;

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

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _messageReceiver.ReceiverAsync<CryptoBought>(null);
    }
}
