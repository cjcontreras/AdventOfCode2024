using ConsoleApp.Days.Day2;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace Tests.Days;

public class Day2SolverTests
{
    private readonly Day2Solver _solver;

    public Day2SolverTests(ITestOutputHelper output)
    {
        // Redirect logs to test output
        var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddXUnit(output); // Add XUnit logger
            builder.SetMinimumLevel(LogLevel.Debug); // Set log level
        });

        ILogger<Day2Solver> logger = loggerFactory.CreateLogger<Day2Solver>();
        _solver = new Day2Solver(logger);
    }

    [Theory]
    [InlineData(new[] { "7 6 4 2 1", "1 2 7 8 9", "9 7 6 2 1", "1 3 2 4 5", "8 6 4 4 1", "1 3 6 7 9" }, "2")]
    [InlineData(new[] { "1 2 4", "4 2 1", "1 3 2", "2 4 5", "4 6 4", "1 3 6" }, "4")]
    public void SolvePt1_ValidInput_ReturnsCorrectResult(string[] input, string expected)
    {
        // Act
        var result = _solver.SolvePt1(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new[] { "7 6 4 2 1", "1 2 7 8 9", "9 7 6 2 1", "1 3 2 4 5", "8 6 4 4 1", "1 3 6 7 9" }, "4")]
    [InlineData(new[] { "1 2 4", "4 2 1", "1 5 1", "2 4 5", "4 6 5", "1 3 6" }, "5")]
    [InlineData(
        new[]
        {
            "2 5 6 8 6", "87 89 90 93 96 99 99", "13 14 15 18 19 23", "67 69 71 72 73 76 82", "29 32 30 31 34 35 37"
        }, "5")]
    public void SolvePt2_ValidInput_ReturnsCorrectResult(string[] input, string expected)
    {
        // Act
        var result = _solver.SolvePt2(input);

        // Assert
        Assert.Equal(expected, result);
    }
}