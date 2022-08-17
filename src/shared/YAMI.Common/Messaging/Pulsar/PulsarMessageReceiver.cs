using System.Reflection;
using System.Text;
using System.Text.Json;
using DotPulsar;
using DotPulsar.Abstractions;
using DotPulsar.Extensions;
using YAMI.Common.Messaging.Models;

namespace YAMI.Common.Messaging.Pulsar;

internal sealed class PulsarMessageReceiver : IMessageReceiver
{
    private readonly IPulsarClient _client;
    private readonly string _consumerName;

    public PulsarMessageReceiver()
    {
        _client = PulsarClient.Builder().Build();
        _consumerName = Assembly.GetEntryAssembly()?.FullName?.Split(',')[0].ToLowerInvariant() ?? string.Empty;
    }

    public async Task ReceiverAsync<T>(ReceivedMessageEnvelope<T> messageReceivePayload) where T : Models.IMessage
    {
        var subscription = $"{_consumerName}_{messageReceivePayload.Topic}";

        var consumer = _client.NewConsumer()
            .SubscriptionName(subscription)
            .Topic($"persistent://public/default/{messageReceivePayload.Topic}")
            .Create();

        await foreach (var message in consumer.Messages())
        {
            var data = Encoding.UTF8.GetString(message.Data.FirstSpan);
            var obj = JsonSerializer.Deserialize<T>(data);
            if (obj is { })
            {
                await messageReceivePayload.Handler(obj);
            }

            await consumer.Acknowledge(message);
        }
    }
}
