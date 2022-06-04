using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using YAMI.Common.Messaging.Models;

namespace YAMI.Common.Messaging.RabbitMQ;

internal sealed class RabbitMQMessageReceiver : IMessageReceiver
{
    private readonly IModel _channel;

    public RabbitMQMessageReceiver()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        var connection = factory.CreateConnection();
        _channel = connection.CreateModel();
    }

    public Task ReceiverAsync<T>(ReceivedMessageEnvelope<T> receiveMessageEnvelope) where T : Models.IMessage
    {
        _channel.QueueDeclare(queue: "hello",
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine(" [x] Received {0}", message);
        };
        _channel.BasicConsume(queue: "hello",
                             autoAck: true,
                             consumer: consumer);
        return Task.CompletedTask;
    }
}
