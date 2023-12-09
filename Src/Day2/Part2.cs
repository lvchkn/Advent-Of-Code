namespace AdventOfCode.Day2;

public class Part2
{
    private readonly Dictionary<string, int> _colors = new()
    {
        ["red"] = 0,
        ["green"] = 0,
        ["blue"] = 0,
    };
    
    public int Solve(string[] inputs)
    {
        var games = inputs.Select(i => 
                i.Substring(i.IndexOf(":", StringComparison.Ordinal) + 1).Trim())
            .ToList();

        var powers = new List<int>();

        foreach (var game in games)
        {
            var sets = game.Split(";");
            ProcessSets(sets);

            var power = _colors.Values.Aggregate((total, next) => total * next);
            powers.Add(power);
            
            ResetContext();
        }

        return powers.Sum();
    }
    
    private void ResetContext()
    {
        foreach (var (key, _) in _colors)
        {
            _colors[key] = 0;
        }
    }

    private void ProcessSets(string[] sets)
    {
        foreach (var set in sets)
        {
            var subsets = set.Split(",");
            ProcessSubsets(subsets);
        }
    }
    
    private void ProcessSubsets(string[] subsets)
    {
        foreach (var subset in subsets)
        {
            var number = ExtractNumber(subset);
            var color = subset.Replace(number.ToString(), "").Trim();

            var maxValue = _colors[color];
            if (number > maxValue)
            {
                maxValue = number;
            }

            _colors[color] = maxValue;
        }
    }

    private static int ExtractNumber(string subset)
    {
        var numberString = new string(subset.Where(char.IsDigit).ToArray());
        var result = int.Parse(numberString);
        
        return result;
    }
}