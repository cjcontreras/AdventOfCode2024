using Microsoft.Extensions.Logging;

namespace ConsoleApp.Days.Day1;

public class Day1Solver(ILogger<Day1Solver> logger) : ISolver
{
    private ILogger<Day1Solver> Logger { get; } = logger;

    public string SolvePt1(string[] input)
    {
        Logger.LogInformation("Solving day 1");
        var leftSide = new List<int>();
        var rightSide = new List<int>();

        foreach (var line in input)
        {
            var sides = line.Split("   ");
            leftSide.Add(int.Parse(sides[0]));
            rightSide.Add(int.Parse(sides[1]));
        }
        
        leftSide.Sort();
        rightSide.Sort();

        var total = leftSide.Select((t, i) => Math.Abs(rightSide[i] - t)).Sum();

        Logger.LogInformation("Finished solving day 1");
        Logger.LogInformation("Total: {Total}", total);
        
        return total.ToString();
    }
    
    public string SolvePt2(string[] input)
    {
        Logger.LogInformation("Solving day 1 pt 2");
        var leftSide = new List<int>();
        var rightSide = new List<int>();

        foreach (var line in input)
        {
            var sides = line.Split("   ");
            leftSide.Add(int.Parse(sides[0]));
            rightSide.Add(int.Parse(sides[1]));
        }
        
        var dictionary = leftSide.Distinct().ToDictionary(x => x, x => rightSide.Count(y => y==x));

        var total = leftSide.Sum(i => i * dictionary[i]);

        Logger.LogInformation("Total: {Total}", total);
        
        return total.ToString();
    }
}