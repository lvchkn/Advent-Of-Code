using AdventOfCodeTests.Utils;
using Xunit;

namespace AdventOfCodeTests.Day1;

public class Part1Tests
{
    [Fact]
    public async Task Example_Input()
    {
        // Arrange
        var inputs = await FileUtils.GetInputAsync(1, $"{FileUtils.ExampleInputFileName}_1");
        
        // Act
        var result = new AdventOfCode.Day1.Part1().Solve(inputs);
        
        // Assert
        Assert.Equal(142, result);
    }
    
    [Fact]
    public async Task Input()
    {
        // Arrange
        var inputs = await FileUtils.GetInputAsync(1, FileUtils.InputFileName);
        
        // Act
        var result = new AdventOfCode.Day1.Part1().Solve(inputs);
        
        // Assert
        Assert.Equal(55834, result);
    }
}