using Microsoft.AspNetCore.Mvc;
using OrionMensageria.Dominio;

namespace OrionMensageria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessengerController : Controller
    {
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpPost("sendMessage")]
        public async Task<IActionResult> sendMessage(Messages messages)
        {

            return Ok();
        }
    }
}
