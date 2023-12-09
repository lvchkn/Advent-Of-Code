using AdventOfCodeTests.Utils;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCodeTests.Day1;

public class Part1Tests(ITestOutputHelper testOutputHelper)
{
    [Fact]
    public async Task Example_Input()
    {
        // Arrange
        var filePath = "Day1/example_input_1.txt";
        var inputs = await FileUtils.GetInputAsync(filePath);
        
        // Act
        var result = AdventOfCode.Day1.Part1.Solve(inputs);
        testOutputHelper.WriteLine($"Day 1 part 1 demo. Answer = {result}");
        
        // Assert
        Assert.Equal(142, result);
    }
    
    [Fact]
    public async Task Input()
    {
        // Arrange
        var filePath = "Day1/input.txt";
        var inputs = await FileUtils.GetInputAsync(filePath);
        
        // Act
        var result = AdventOfCode.Day1.Part1.Solve(inputs);
        testOutputHelper.WriteLine($"Day 1 part 1. Answer = {result}");
    }
}