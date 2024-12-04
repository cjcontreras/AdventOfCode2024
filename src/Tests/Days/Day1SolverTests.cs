using ConsoleApp.Days.Day1;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;
using Assert = Xunit.Assert;

namespace Tests.Days;

public class Day1SolverTests
{
    private readonly ILogger<Day1Solver> _logger;
    private readonly Day1Solver _solver;

    public Day1SolverTests(ITestOutputHelper output)
    {
        // Redirect logs to test output
        var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddXUnit(output); // Add XUnit logger
            builder.SetMinimumLevel(LogLevel.Debug); // Set log level
        });

        _logger = loggerFactory.CreateLogger<Day1Solver>();
        _solver = new Day1Solver(_logger);
    }

    [Theory]
    [InlineData(new[] { "1   5", "3   7" }, "8")]
    [InlineData(new[] { "3   4", "4   3", "2   5", "1   3", "3   9", "3   3" }, "11")]
    public void SolvePt1_ValidInput_ReturnsCorrectResult(string[] input, string expected)
    {
        // Act
        var result = _solver.SolvePt1(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new[] { "1   5", "3   7" }, "0")]
    [InlineData(new[] { "3   4", "4   3", "2   5", "1   3", "3   9", "3   3" }, "31")]
    public void SolvePt2_ValidInput_ReturnsCorrectResult(string[] input, string expected)
    {
        // Act
        var result = _solver.SolvePt2(input);

        // Assert
        Assert.Equal(expected, result);
    }
}