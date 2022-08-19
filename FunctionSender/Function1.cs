using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Azure.Messaging.ServiceBus;

namespace BusSender
{
    public class Function1
    {
        private readonly ServiceBusClient _serviceBusClient;
        public Function1(ServiceBusClient serviceBusClient)
        {
            _serviceBusClient = serviceBusClient;
        }

        [FunctionName("Function1")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string message = req.Query["message"];


            var sender = _serviceBusClient.CreateSender("topic");
            // create a message that we can send. UTF-8 encoding is used when providing a string.
            ServiceBusMessage bMessage = new ServiceBusMessage(message);

            // send the message
            for (int i = 0; i < 1000000; i++)
            {
                await sender.SendMessageAsync(bMessage);

            }


            return new OkResult();
        }
    }
}
