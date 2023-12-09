using AdventOfCodeTests.Utils;
using Xunit;

namespace AdventOfCodeTests.Day2;

public class Part2Tests
{
    [Fact]
    public async Task Example_Input()
    {
        // Arrange
        var input = await FileUtils.GetInputAsync(2, FileUtils.ExampleInputFileName);
        
        // Act
        var result = new AdventOfCode.Day2.Part2().Solve(input);
        
        // Assert
        Assert.Equal(2286, result);
    }
    
    [Fact]
    public async Task Input()
    {
        // Arrange
        var input = await FileUtils.GetInputAsync(2, FileUtils.InputFileName);
        
        // Act
        var result = new AdventOfCode.Day2.Part2().Solve(input);
        
        // Assert
        Assert.Equal(83707, result);
    }
}