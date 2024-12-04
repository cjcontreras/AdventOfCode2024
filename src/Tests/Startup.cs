using ConsoleApp.Days;
using ConsoleApp.Days.Day1;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Tests;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Configure logging for tests
        services.AddLogging(builder =>
        {
            builder.ClearProviders();
            builder.AddSerilog(new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger());
        });

        // Register solvers
        services.AddTransient<Day1Solver>();
        services.AddTransient<Func<string, ISolver>>(serviceProvider => key =>
        {
            return key switch
            {
                "Day1" => serviceProvider.GetService<Day1Solver>(),
                _ => throw new ArgumentException($"No solver found for {key}"),
            };
        });
    }
}