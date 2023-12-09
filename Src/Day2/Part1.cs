namespace AdventOfCode.Day2;

public class Part1
{
    private record ColorContext(int CurrentCount, int Limit);

    private readonly Dictionary<string, ColorContext> _colors = new()
    {
        ["red"] = new (0, 12),
        ["green"] = new (0, 13),
        ["blue"] = new (0, 14),
    };
    
    public int Solve(string[] inputs)
    {
        var games = inputs.Select(i => 
                i.Substring(i.IndexOf(":", StringComparison.Ordinal) + 1).Trim())
            .ToList();

        var possibleGames = new List<int>();
        
        for (var i = 0; i < games.Count; i++)
        {
            var sets = games[i].Split(";");

            if (!IsGamePossible(sets)) continue;
            
            possibleGames.Add(i + 1);
        }

        return possibleGames.Sum();
    }

    private void ResetContext()
    {
        foreach (var (key, _) in _colors)
        {
            _colors[key] = _colors[key] with
            {
                CurrentCount = 0
            };
        }
    }

    private bool IsGamePossible(string[] sets)
    {
        foreach (var set in sets)
        {
            var subsets = set.Split(",");
            ProcessSubsets(subsets);
            
            var isBeyondLimit = _colors.Values.Any(r => r.CurrentCount > r.Limit);
            
            ResetContext();
            
            if (isBeyondLimit) return false;
        }

        return true;
    }
    
    private void ProcessSubsets(string[] subsets)
    {
        foreach (var subset in subsets)
        {
            var number = ExtractNumber(subset);
                    
            var color = subset.Replace(number.ToString(), "").Trim();
            var newCurrent = _colors[color].CurrentCount + number;
            
            _colors[color] = _colors[color] with
            {
                CurrentCount = newCurrent,
            };
        }
    }

    private static int ExtractNumber(string subset)
    {
        var numberString = new string(subset.Where(char.IsDigit).ToArray());
        var result = int.Parse(numberString);
        
        return result;
    }
}