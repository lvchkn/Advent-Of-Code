using AdventOfCodeTests.Utils;
using Xunit;

namespace AdventOfCodeTests.Day3;

public class Part1Tests
{
    [Fact]
    public async Task Example_Input()
    {
        // Arrange
        var input = await FileUtils.GetInputAsync(3, FileUtils.ExampleInputFileName);
        
        // Act
        var result = new AdventOfCode.Day3.Part1().Solve(input);
        
        //Assert
        Assert.Equal(4361, result);
    }
    
    [Fact]
    public async Task Input()
    {
        // Arrange
        var input = await FileUtils.GetInputAsync(3, FileUtils.InputFileName);
        
        // Act
        var result = new AdventOfCode.Day3.Part1().Solve(input);
        
        //Assert
        Assert.Equal(540131, result);
    }
}