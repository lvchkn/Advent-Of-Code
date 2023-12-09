using AdventOfCodeTests.Utils;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCodeTests.Day2;

public class Part2Tests(ITestOutputHelper testOutputHelper)
{
    [Fact]
    public async Task Example_Input()
    {
        // Arrange
        var filePath = "Day2/example_input.txt";
        var input = await FileUtils.GetInputAsync(filePath);
        
        // Act
        var result = AdventOfCode.Day2.Part2.Solve(input);
        testOutputHelper.WriteLine($"Day 2 part 2 demo. Answer = {result}");
        
        // Assert
        Assert.Equal(2286, result);
    }
    
    [Fact]
    public async Task Input()
    {
        // Arrange
        var filePath = "Day2/input.txt";
        var input = await FileUtils.GetInputAsync(filePath);
        
        // Act
        var result = AdventOfCode.Day2.Part2.Solve(input);
        testOutputHelper.WriteLine($"Day 2 part 2. Answer = {result}");
    }
}