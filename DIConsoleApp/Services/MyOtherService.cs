using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIConsoleApp.Services
{
    public class MyOtherService : IMyService
    {
        private readonly string _baseUrl;
        private readonly string _token;
        private readonly ILogger<MyOtherService> _logger;

        public MyOtherService(ILoggerFactory loggerFactory, IConfigurationRoot config)
        {
            var baseUrl = config["SomeConfigItem:BaseUrl"];
            var token = config["SomeConfigItem:Token"];

            _baseUrl = baseUrl;
            _token = token;
            _logger = loggerFactory.CreateLogger<MyOtherService>();
        }

        public async Task MyServiceMethod()
        {
            Console.WriteLine("My service method has run!");
            _logger.LogDebug(_baseUrl);
            _logger.LogDebug(_token);
        }
    }
}
