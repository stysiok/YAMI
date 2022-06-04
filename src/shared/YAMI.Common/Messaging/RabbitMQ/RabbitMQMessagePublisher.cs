using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using YAMI.Common.Messaging.Models;

namespace YAMI.Common.Messaging.RabbitMQ;

internal sealed class RabbitMQMessagePublisher : IMessagePublisher
{
    private readonly IConnection _connection;

    public RabbitMQMessagePublisher()
    {
        _connection = new ConnectionFactory() { HostName = "localhost" }.CreateConnection();
    }

    public async Task PublishAsync<T>(PublishMessageEnvelope<T> messagePublishPayload) where T : Models.IMessage
    {
        using var channel = _connection.CreateModel();
        channel.QueueDeclare(queue: "hello",
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        var message = JsonSerializer.Serialize(messagePublishPayload.Message);
        var body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish(exchange: "",
                             routingKey: "hello",
                             basicProperties: null,
                             body: body);
        Console.WriteLine("[x] Sent {0}", message);
    }
}
