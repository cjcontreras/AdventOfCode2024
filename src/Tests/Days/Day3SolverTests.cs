using ConsoleApp.Days.Day3;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace Tests.Days;

public class Day3SolverTests
{
    private readonly Day3Solver _solver;

    public Day3SolverTests(ITestOutputHelper output)
    {
        // Redirect logs to test output
        var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddXUnit(output); // Add XUnit logger
            builder.SetMinimumLevel(LogLevel.Debug); // Set log level
        });

        ILogger<Day3Solver> logger = loggerFactory.CreateLogger<Day3Solver>();
        _solver = new Day3Solver(logger);
    }

    [Theory]
    [InlineData(new[] { "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))" }, "161")]
    public void SolvePt1_ValidInput_ReturnsCorrectResult(string[] input, string expected)
    {
        // Act
        var result = _solver.SolvePt1(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new[] { "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))" }, "48")]
    public void SolvePt2_ValidInput_ReturnsCorrectResult(string[] input, string expected)
    {
        // Act
        var result = _solver.SolvePt2(input);

        // Assert
        Assert.Equal(expected, result);
    }
}