using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace BusTest
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;

        public Function1(ILogger<Function1> log)
        {
            _logger = log;
        }

        [FunctionName("Function1")]
        public void Run([ServiceBusTrigger("topic", "sub", Connection = "connstring")]string mySbMsg)
        {
            _logger.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg}");
        }
    }
}
