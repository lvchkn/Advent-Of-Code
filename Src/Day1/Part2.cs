using System.Text;

namespace AdventOfCode.Day1;

public class Part2
{
    private readonly Dictionary<string, int> _numbers = new()
    {
        ["one"] = 1,
        ["two"] = 2,
        ["three"] = 3,
        ["four"] = 4,
        ["five"] = 5,
        ["six"] = 6,
        ["seven"] = 7,
        ["eight"] = 8,
        ["nine"] = 9,
    };
    
    public int Solve(string[] inputs)
    {
        var sum = 0;

        foreach (var input in inputs)
        {
            var number = ExtractNumber(input);
            sum += number;
        }

        return sum;
    }
    
    private int ExtractNumber(string input)
    {
        var numberIndexes = GetNumberIndexes(input);

        var firstNumber = numberIndexes.MinBy(kvp => kvp.Key).Value;
        var lastNumber = numberIndexes.MaxBy(kvp => kvp.Key).Value;
        
        var firstNumberChar = (char)(firstNumber + 48);
        var lastNumberChar = (char)(lastNumber + 48);

        var resultChars = numberIndexes.Count == 1
            ? new[] { firstNumberChar, firstNumberChar }
            : new[] { firstNumberChar, lastNumberChar };
        
        var numberString = new string(resultChars);
        
        return int.Parse(numberString);
    }

    private Dictionary<int, int> GetNumberIndexes(string input)
    {
        var numberIndexes = new Dictionary<int, int>();
        var sb = new StringBuilder();
        
        for (var i = 0; i < input.Length; i++)
        {
            for (var j = i; j < input.Length; j++)
            {
                var currentChar = input[j];
                sb.Append(currentChar);

                if (char.IsDigit(sb[0]))
                {
                    numberIndexes.Add(i, (int)char.GetNumericValue(currentChar));
                    sb.Clear();
                    break;
                }
                if (_numbers.TryGetValue(sb.ToString(), out var value))
                {
                    numberIndexes.Add(i, value);
                    sb.Clear();
                    break;
                }
            }
            sb.Clear();
        }

        return numberIndexes;
    }
}