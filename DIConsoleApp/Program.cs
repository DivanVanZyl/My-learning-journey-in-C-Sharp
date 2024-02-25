using DIConsoleApp;
using DIConsoleApp.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

Console.WriteLine("App Started.");

IServiceCollection services = new ServiceCollection();
// Startup.cs finally :)
Startup startup = new Startup();
startup.ConfigureServices(services);
IServiceProvider serviceProvider = services.BuildServiceProvider();

//configure console logging

var logger = serviceProvider.GetService<ILoggerFactory>()
    .CreateLogger<Program>();

logger.LogDebug("Logger is working!");

// Get Service and call method
var service = serviceProvider.GetService<IMyService>();
service.MyServiceMethod();  