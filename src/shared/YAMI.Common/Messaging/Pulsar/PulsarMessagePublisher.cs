using System.Buffers;
using System.Collections.Concurrent;
using System.Reflection;
using System.Text;
using System.Text.Json;
using DotPulsar;
using DotPulsar.Abstractions;
using DotPulsar.Extensions;
using YAMI.Common.Messaging.Models;

namespace YAMI.Common.Messaging.Pulsar;

internal sealed class PulsarMessagePublisher : IMessagePublisher
{
    private readonly ConcurrentDictionary<MessageTopic, IProducer<ReadOnlySequence<byte>>> _producers = new();
    private readonly IPulsarClient _client;
    private readonly string _producerName;

    public PulsarMessagePublisher()
    {
        _client = PulsarClient.Builder().Build();
        _producerName = Assembly.GetEntryAssembly()?.FullName?.Split(',')[0].ToLowerInvariant() ?? string.Empty;
    }

    public async Task PublishAsync<T>(PublishMessageEnvelope<T> messagePublishPayload) where T : Models.IMessage
    {
        var producer = _producers.GetOrAdd(messagePublishPayload.Topic, _client.NewProducer()
            .ProducerName(_producerName)
            .Topic($"persistent://public/default/{messagePublishPayload.Topic}")
            .Create());

        var message = JsonSerializer.Serialize(messagePublishPayload.Message);
        var body = Encoding.UTF8.GetBytes(message);

        var messageId = await producer.Send(body);
    }
}
