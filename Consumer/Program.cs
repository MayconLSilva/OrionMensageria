using Newtonsoft.Json;
using OrionMensageria.Dominio;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
//Here we specify the Rabbit MQ Server. we use rabbitmq docker image and use it
var message = (dynamic)null;
var _factory = new ConnectionFactory()
{
    HostName = "localhost"
};

using (var connection = _factory.CreateConnection())

using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "bemvindo",
                         durable: false,
                         exclusive: false,
                         autoDelete: false,
                         arguments: null);

    var consumer = new EventingBasicConsumer(channel);

    consumer.Received += (model, eventArgs) =>
    {
        var body = eventArgs.Body.ToArray();
        var contentString = Encoding.UTF8.GetString(body);
        System.Diagnostics.Debug.WriteLine("Inicio a leitura");
        
        System.Diagnostics.Debug.WriteLine($"Primeira Opção {contentString}");
        Console.WriteLine($"Segunda Opção {contentString}"); //este aqui

        message = JsonConvert.DeserializeObject<Messages>(contentString);
        System.Diagnostics.Debug.WriteLine($"Terceira Opção {message}");
        Console.WriteLine($"Quarta Opção {message}");

        // channel.BasicAck(eventArgs.DeliveryTag, false);
    };
   

    channel.BasicConsume(queue: "bemvindo",
                         autoAck: true,
                         consumer: consumer);
}
Console.ReadKey();