using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace CreditApplicationSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly IConnection _rabbitConnection;

        public ApplicationController(IConnection rabbitConnection)
        {
            _rabbitConnection = rabbitConnection;
        }

        [HttpPost]
        public IActionResult SubmitApplication([FromBody] CreditApplication application)
        {
            using (var channel = _rabbitConnection.CreateModel())
            {
                channel.QueueDeclare(queue: "credit_applications", durable: false, exclusive: false, autoDelete: false, arguments: null);
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(application));
                channel.BasicPublish(exchange: "", routingKey: "credit_applications", basicProperties: null, body: body);
            }

            return Ok();
        }
    }
}