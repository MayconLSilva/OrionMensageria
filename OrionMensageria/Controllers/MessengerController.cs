using Microsoft.AspNetCore.Mvc;
using OrionMensageria.Dominio;
using RabbitMQ.Client;
using System.Text;

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

                string postMensagem = objMsg.mensagem;

                var body = Encoding.UTF8.GetBytes(postMensagem);

                channel.BasicPublish(exchange: "",
                                     routingKey: "bemvindo",
                                     basicProperties: null,
                                     body: body);
            }

            return Ok();
        }
    }
}
