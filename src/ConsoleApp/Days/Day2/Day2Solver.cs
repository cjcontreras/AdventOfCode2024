using Microsoft.Extensions.Logging;

namespace ConsoleApp.Days.Day2;

public class Day2Solver(ILogger<Day2Solver> logger) : ISolver
{
    private ILogger<Day2Solver> Logger { get; } = logger;

    public string SolvePt1(string[] input)
    {
        var safeLevels = 0;

        foreach (var line in input)
        {
            var levels = line.Split(" ");
            var isSafe = IsLevelSafeLoop(levels).Item1;
            if (isSafe)
                safeLevels++;
        }

        return safeLevels.ToString();
    }

    public string SolvePt2(string[] input)
    {
        var safeLevels = 0;

        foreach (var line in input)
        {
            var levels = line.Split(" ");
            var isSafe = IsLevelSafeLoop(levels).Item1;

            if (!isSafe)
            {
                for (var i = 0; i < levels.Length; i++)
                {
                    var currentLevel = levels.Where((source, index) => index != i).ToArray();
                    isSafe = IsLevelSafeLoop(currentLevel).Item1;
                    if (isSafe)
                        break;
                }
            }

            if (isSafe)
                safeLevels++;
        }

        return safeLevels.ToString();
    }

    private static (bool, int) IsLevelSafeLoop(string[] levels)
    {
        var previousLevel = int.Parse(levels[0]);

        var isAscending = false;
        var isDescending = false;
        for (var i = 1; i < levels.Length; i++)
        {
            var currentLevel = int.Parse(levels[i]);
            var difference = Math.Abs(previousLevel - currentLevel);

            if (difference is < 1 or > 3)
                return (false, i);

            if (previousLevel > currentLevel)
            {
                isDescending = true;
            }

            if (previousLevel < currentLevel)
            {
                isAscending = true;
            }

            if (isAscending && isDescending)
                return (false, i);

            previousLevel = currentLevel;
        }

        return (true, 0);
    }
}