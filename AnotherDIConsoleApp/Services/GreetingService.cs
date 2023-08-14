using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherDIConsoleApp.Services
{
    public class GreetingService : IGreetingService
    {
        private readonly ILogger<GreetingService> _log;
        private readonly IConfiguration _config;
        public GreetingService(ILogger<GreetingService> log, IConfiguration config)
        {
            _log = log;
            _config = config;
        }
        public void Run()
        {
            for(int cnt = 0; cnt < _config.GetValue<int>("LoopTimes"); cnt++)
            {
                _log.LogInformation("Run number {runNumber}",cnt);
            }
        }
    }
}
