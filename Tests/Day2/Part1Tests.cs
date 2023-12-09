using AdventOfCodeTests.Utils;
using Xunit;

namespace AdventOfCodeTests.Day2;

public class Part1Tests
{
    [Fact]
    public async Task Example_Input()
    {
        // Arrange
        var input = await FileUtils.GetInputAsync(2, FileUtils.ExampleInputFileName);
        
        // Act
        var result = new AdventOfCode.Day2.Part1().Solve(input);
        
        //Assert
        Assert.Equal(8, result);
    }
    
    [Fact]
    public async Task Input()
    {
        // Arrange
        var input = await FileUtils.GetInputAsync(2, FileUtils.InputFileName);
        
        // Act
        var result = new AdventOfCode.Day2.Part1().Solve(input);
        
        // Assert
        Assert.Equal(2685, result);
    }
}