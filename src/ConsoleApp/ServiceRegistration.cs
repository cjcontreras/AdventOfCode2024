using ConsoleApp.Days;
using ConsoleApp.Days.Day1;
using ConsoleApp.Days.Day2;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace ConsoleApp;

public static class ServiceRegistration
{
    public static ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        // Configure logging
        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders();
            loggingBuilder.AddSerilog(new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger());
        });

        // Register solvers
        services.AddTransient<Day1Solver>();
        services.AddTransient<Day2Solver>();

        // Register a factory for dynamic solver resolution
        services.AddTransient<Func<string, ISolver>>(serviceProvider => key =>
        {
            return key switch
            {
                "Day1" => serviceProvider.GetService<Day1Solver>(),
                "Day2" => serviceProvider.GetService<Day2Solver>(),
                _ => throw new ArgumentException($"No solver found for {key}")
            };
        });

        return services.BuildServiceProvider();
    }
}
