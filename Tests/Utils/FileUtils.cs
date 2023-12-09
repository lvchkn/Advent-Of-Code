namespace AdventOfCodeTests.Utils;

public static class FileUtils
{
    public const string InputFileName = "input";
    public const string ExampleInputFileName = "example_input";

    public static async Task<string[]> GetInputAsync(byte day, string fileName = "")
    {
        var path = Path.Combine("..", "..", "..", "..", "aoc-inputs", "2023", $"Day{day}", $"{fileName}.txt");
        using var sr = new StreamReader(path);
        var inputs = await sr.ReadToEndAsync();
        var splitInputs = inputs.Split(Environment.NewLine);

        return splitInputs;
    }
}