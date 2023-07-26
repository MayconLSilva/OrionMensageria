using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OrionMensageria.Dominio;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading.Channels;

namespace OrionMensageria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessengerController : Controller
    {
        private readonly ConnectionFactory _factory;
        public MessengerController()
        {
            _factory = new ConnectionFactory() 
            { 
                HostName = "localhost"
            };

        }

        [HttpPost("sendMessage")]
        public async Task<IActionResult> sendMessage(Messages objMsg)
        {
            using (var connection = _factory.CreateConnection())

            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "bemvindo",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                // string postMensagem = objMsg.mensagem;
                var json = JsonConvert.SerializeObject(objMsg);

                var body = Encoding.UTF8.GetBytes(json);

                channel.BasicPublish(exchange: "",
                                     routingKey: "bemvindo",
                                     basicProperties: null,
                                     body: body);
            }

            return Ok();
        }

        [HttpGet("readMessage")]
        public async Task<IActionResult> readMessage()
        {
            var message = (dynamic)null;

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
                    System.Diagnostics.Debug.WriteLine($"1 Tentativa leitura {contentString}");

                    message = JsonConvert.DeserializeObject<Messages>(contentString);
                    System.Diagnostics.Debug.WriteLine($"2 Tentativa leitura {message}");

                    // channel.BasicAck(eventArgs.DeliveryTag, false);
                };
                System.Diagnostics.Debug.WriteLine("Inicio a leitura");
                
                System.Diagnostics.Debug.WriteLine($"2 Tentativa leitura {message}");

                channel.BasicConsume(queue: "bemvindo",
                                     autoAck: true,
                                     consumer: consumer);
            }
            return Ok(message);
        }
    }
}
