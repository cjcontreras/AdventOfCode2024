using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;

namespace ConsoleApp.Days.Day3;

public partial class Day3Solver(ILogger<Day3Solver> logger) : ISolver
{
    private ILogger<Day3Solver> Logger { get; } = logger;
    private Regex SolverRegex = MyRegex();
    private Regex DigitRegex = MyRegex1();


    public string SolvePt1(string[] input)
    {
        var total = 0;
        var matches = SolverRegex.Matches(string.Join(" ", input));

        foreach (var match in matches)
        {
            var pattern = match.ToString();
            var digits = DigitRegex.Matches(pattern);
            var x = int.Parse(digits[0].ToString());
            var y = int.Parse(digits[1].ToString());
            total += x * y;
        }

        return total.ToString();
    }

    public string SolvePt2(string[] input)
    {
        var total = 0;
        Logger.LogInformation(input.Length.ToString());
        var line = string.Join(" ", input);

        var doMultiple = line.Split("do()");
        if (doMultiple.Length == 1)
        {
            var sanityCheck = line.Split("don't()");

            var matches = SolverRegex.Matches(sanityCheck[0]);

            foreach (var match in matches)
            {
                var pattern = match.ToString();
                var digits = DigitRegex.Matches(pattern);
                var x = int.Parse(digits[0].ToString());
                var y = int.Parse(digits[1].ToString());
                total += x * y;
            }
        }

        foreach (var item in doMultiple)
        {
            var split = item.Split("don't()");
            var matches = SolverRegex.Matches(split[0]);

            foreach (var match in matches)
            {
                var pattern = match.ToString();
                var digits = DigitRegex.Matches(pattern);
                var x = int.Parse(digits[0].ToString());
                var y = int.Parse(digits[1].ToString());
                total += x * y;
            }
        }

        return total.ToString();
    }

    [GeneratedRegex(@"mul\(\d+,\d+\)", RegexOptions.Compiled)]
    private static partial Regex MyRegex();

    [GeneratedRegex(@"\d+", RegexOptions.Compiled)]
    private static partial Regex MyRegex1();
}