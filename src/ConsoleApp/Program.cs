using ConsoleApp.Days.Day3;
using ConsoleApp.Utils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace ConsoleApp;

internal class Program
{
    private static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug() // Set minimum log level
            .WriteTo.Console() // Log to console
            .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day) // Log to file
            .CreateLogger();

        var serviceProvider = ServiceRegistration.ConfigureServices();

        var logger = serviceProvider.GetService<ILogger<Program>>();
        logger.LogInformation("Application has started");


        try
        {
            var day3Solver = serviceProvider.GetService<Day3Solver>();
            var input = InputReader.ReadLines("Day3Input.txt", "Day3");
            var result = day3Solver!.SolvePt2(input);
            logger.LogInformation("Day 3 Pt 2 Solution: {Result}", result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred");
        }
        finally
        {
            Log.CloseAndFlush(); // Ensure logs are written before app exits
        }
    }
}