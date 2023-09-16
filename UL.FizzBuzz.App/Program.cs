using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using UL.FizzBuzz.App;
using UL.FizzBuzz.App.Services;


using IHost host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;

try
{
    services.GetRequiredService<App>().Run(args);
}
catch (Exception exception)
{
    Console.WriteLine("An error occured");
    var logger = host.Services.GetService<ILogger<Program>>();
    logger.LogError(exception.Message); //This is a very very simple implementation, can be enhanced regarding the requirements
    logger.LogError(exception.StackTrace);
}

IHostBuilder CreateHostBuilder(string[] strings)
{
    return Host.CreateDefaultBuilder()
        .ConfigureServices((_, services) =>
        {
            services.AddSingleton<ICalculationService, CalculationService>();
            services.AddSingleton<App>();
        })
        .UseSerilog((context, configuration) =>
        {
            //Configuration can be customized regarding to the requirements, can be logged to a database and monitors tools can be configured in a prod environment
            configuration
                .MinimumLevel.Information()
                .WriteTo.File(
                    "logs/log.txt",
                    fileSizeLimitBytes: 1_000_000, 
                    rollOnFileSizeLimit: true,
                    flushToDiskInterval: TimeSpan.FromSeconds(1),
                    retainedFileCountLimit: 10)
                .Enrich.FromLogContext();
        });
}
