namespace AdventOfCodeTests.Utils;

public static class FileUtils
{
    public static async Task<string[]> GetInputAsync(string fileName)
    {
        using var sr = new StreamReader(fileName);
        var inputs = await sr.ReadToEndAsync();
        var splitInputs = inputs.Split(Environment.NewLine);

        return splitInputs;
    }
}