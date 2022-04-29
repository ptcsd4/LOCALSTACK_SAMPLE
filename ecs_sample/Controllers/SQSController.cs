using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ecs_sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SQSController : ControllerBase
    {
        private readonly ILogger<SQSController> _logger;

        public SQSController(ILogger<SQSController> logger)
        {
            _logger = logger;
        }

        [HttpPut]
        public async Task<string> Put()
        {
            _logger.LogInformation("test for put !");
            _logger.LogInformation(EnvironmentVariable.GET_SQS_ENDPOINT());
            _logger.LogInformation(EnvironmentVariable.GET_SQS_NAME());

            var client = new AmazonSQSClient(
                 new AmazonSQSConfig
                 {
                     ServiceURL = EnvironmentVariable.GET_SQS_ENDPOINT()
                 }
             );

            var resp = await client.GetQueueUrlAsync(EnvironmentVariable.GET_SQS_NAME());

            var sendMessageRequest = new SendMessageRequest
            {
                QueueUrl = resp.QueueUrl,
                MessageBody = System.Text.Json.JsonSerializer.Serialize("boga")
            };

            await client.SendMessageAsync(sendMessageRequest);

            return "ok";
        }
    }
}