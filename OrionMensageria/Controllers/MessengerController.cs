using Consumer.Dominio;
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
        public async Task<IActionResult> sendMessage(Notification_Mensageria objMsg)
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
            var notification = (dynamic)null;
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
                    //System.Diagnostics.Debug.WriteLine("Inicio a leitura");

                    //System.Diagnostics.Debug.WriteLine($"Primeira Opção {contentString}");
                    Console.WriteLine($"Segunda Opção {contentString}"); //este aqui

                    var message = JsonConvert.DeserializeObject<Notification_Mensageria>(contentString);
                    notification = new Notification_Mensageria()
                    {
                        tipo = message.tipo,
                        assunto = message.assunto,
                        cliente = message.cliente,
                        mensagem = message.mensagem
                    };


                    // message = JsonConvert.DeserializeObject<Messages>(contentString);
                    //System.Diagnostics.Debug.WriteLine($"Terceira Opção {message}");
                    // Console.WriteLine($"Quarta Opção {message}");

                    // channel.BasicAck(eventArgs.DeliveryTag, false);
                };


                channel.BasicConsume(queue: "bemvindo",
                                     autoAck: true,
                                     consumer: consumer);


                Console.WriteLine();
                return Ok(notification);
            }
        }
    }
}
