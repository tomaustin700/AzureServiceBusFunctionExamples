using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Azure;
using System;
using System.Configuration;

[assembly: FunctionsStartup(typeof(BusSender.Startup))]


namespace BusSender
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var connstring = Environment.GetEnvironmentVariable("connstring");

            builder.Services.AddAzureClients(azure => azure.AddServiceBusClient(connstring));


        }
    }
}