using AdventOfCodeTests.Utils;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCodeTests.Day1;

public class Part2Tests(ITestOutputHelper testOutputHelper)
{
    [Fact]
    public async Task Example_Input()
    {
        // Arrange
        var filePath = "Day1/example_input_2.txt";
        var inputs = await FileUtils.GetInputAsync(filePath);
        
        // Act
        var result = AdventOfCode.Day1.Part2.Solve(inputs);
        testOutputHelper.WriteLine($"Day 1 part 2 demo. Answer = {result}");
        
        //Assert
        Assert.Equal(281, result);
    }
    
    [Fact]
    public async Task Input()
    {
        // Arrange
        var filePath = "Day1/input.txt";
        var inputs = await FileUtils.GetInputAsync(filePath);
        
        // Act
        var result = AdventOfCode.Day1.Part2.Solve(inputs);
        testOutputHelper.WriteLine($"Day 1 part 2. Answer = {result}");
    }
}