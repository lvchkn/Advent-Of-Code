using AdventOfCodeTests.Utils;
using Xunit;

namespace AdventOfCodeTests.Day3;

public class Part2FuncTests
{
    [Fact]
    public async Task Example_Input()
    {
        // Arrange
        var input = await FileUtils.GetInputAsync(3, FileUtils.ExampleInputFileName);
        
        // Act
        var result = new AdventOfCode.Day3.Part2Func().Solve(input);
        
        //Assert
        Assert.Equal(467835, result);
    }
    
    [Fact]
    public async Task Input()
    {
        // Arrange
        var input = await FileUtils.GetInputAsync(3, FileUtils.InputFileName);
        
        // Act
        var result = new AdventOfCode.Day3.Part2Func().Solve(input);
        
        //Assert
        Assert.Equal(86879020, result);
    }
}