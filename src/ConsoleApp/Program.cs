using ConsoleApp.Days;
using ConsoleApp.Days.Day1;
using ConsoleApp.Utils;
using Microsoft.Extensions.DependencyInjection;


class Program
{
    static void Main(string[] args)
    {
        var input = InputReader.ReadLines("Day1Input.txt");
        var solver = new Day1Solver();
        var solutionOutput = solver.Solve(input);
        Console.WriteLine("Day 1 Output: " + solutionOutput);
    }

    static ServiceProvider ConfigureServices()
    {
        // Set up the service collection
        var services = new ServiceCollection();

        // Register services
        services.AddTransient<ISolver, Day1Solver>(); // Add Day1Solver

        // Build the service provider
        return services.BuildServiceProvider();
    }
}