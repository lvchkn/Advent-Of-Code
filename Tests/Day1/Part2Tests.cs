using AdventOfCodeTests.Utils;
using Xunit;

namespace AdventOfCodeTests.Day1;

public class Part2Tests
{
    [Fact]
    public async Task Example_Input()
    {
        // Arrange
        var inputs = await FileUtils.GetInputAsync(1, $"{FileUtils.ExampleInputFileName}_2");
        
        // Act
        var result = new AdventOfCode.Day1.Part2().Solve(inputs);
        
        //Assert
        Assert.Equal(281, result);
    }
    
    [Fact]
    public async Task Input()
    {
        // Arrange
        var inputs = await FileUtils.GetInputAsync(1, FileUtils.InputFileName);
        
        // Act
        var result = new AdventOfCode.Day1.Part2().Solve(inputs);
        
        //Assert
        Assert.Equal(53221, result);
    }
}