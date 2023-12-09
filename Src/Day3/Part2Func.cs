using System.Text;

namespace AdventOfCode.Day3;

public class Part2Func
{
    private const int MaxNumberOfAdjacentNumbers = 2;

    private record NumberContext(int Row, int[] Columns, int Value)
    {
        public override string ToString()
        {
            var sb = new StringBuilder($"Row = {Row} Columns = [");

            foreach (var column in Columns)
            {
                sb.Append($" {column},");
            }

            sb.Append($"] Value = {Value}");
            
            return sb.ToString();
        }
    }
    
    private record Arg(string[] Inputs, 
        List<NumberContext> Gears, 
        List<NumberContext> AllNumbers,
        int Row, 
        int Column);
    
    public int Solve(string[] inputs)
    {
        var allNumbers = GetNumbersWithContext(inputs);
        var gears = new List<NumberContext>();
        var sum = 0;
        
        for (var i = 0; i < inputs.Length; i++)
        {
            for (var j = 0; j < inputs[i].Length; j++)
            {
                if (inputs[i][j] != '*') continue;
                
                var arg = new Arg(inputs, gears, allNumbers, i, j);
                var verticalMatches = GetVerticallyAdjacentGears(arg);
                var horizontalMatches = GetHorizontallyAdjacentGears(arg);
                var diagonalMatches = GetDiagonallyAdjacentGears(arg);

                var allMatches = verticalMatches.Union(horizontalMatches)
                    .Union(diagonalMatches)
                    .ToList();
                
                if (allMatches.Count != MaxNumberOfAdjacentNumbers) continue;
                
                gears.AddRange(allMatches);
                var gearRatio = allMatches[0].Value * allMatches[1].Value;
                sum += gearRatio;
            }
        }
        
        return sum;
    }
    
    private static List<NumberContext> GetNumbersWithContext(string[] inputs)
    {
        var indexes = new List<int>();
        var allNumbers = new List<NumberContext>();

        for (var i = 0; i < inputs.Length; i++)
        {
            for (var j = 0; j < inputs[i].Length; j++)
            { 
                if (char.IsDigit(inputs[i][j]))
                {
                    indexes.Add(j);
                    if (j != inputs[i].Length - 1) continue;
                }

                if (indexes.Count > 0)
                {
                    var digits = indexes
                        .Select(index => inputs[i][index])
                        .ToArray();
                        
                    var number = int.Parse(new string(digits));
                    allNumbers.Add(new NumberContext(
                        i,
                        indexes.ToArray(),
                        number));
                }
                
                indexes.Clear();
            }
        }

        return allNumbers;
    }

    private static bool IsDigit(char ch) => char.IsDigit(ch);
    
    private static bool IsChecked(IEnumerable<NumberContext> gears, int i, int j)
    {
        return gears.Any(gear => gear.Row == i && (gear.Columns.Contains(j - 1)
                                                    || gear.Columns.Contains(j + 1)));
    }

    private static NumberContext FindGear(IEnumerable<NumberContext> numbers, int i, int j)
    {
        return numbers.First(n => n.Row == i && n.Columns.Contains(j));
    }

    private static IEnumerable<NumberContext> GetHorizontallyAdjacentGears(Arg arg)
    {
        var (inputs, gears, allNumbers, i, j) = arg;

        var isDigitLeft = IsDigit(inputs[i][j - 1]);
        if (j > 0 && isDigitLeft && !IsChecked(gears, i, j - 1))
        {
            var gear = FindGear(allNumbers, i, j - 1);
            yield return gear;
        }
        
        var isDigitRight = IsDigit(inputs[i][j + 1]);
        if (j < inputs[0].Length - 1 && isDigitRight && !IsChecked(gears, i, j + 1))
        {
            var gear = FindGear(allNumbers, i, j + 1);
            yield return gear;
        }
    }
    
    private static IEnumerable<NumberContext> GetVerticallyAdjacentGears(Arg arg)
    {
        var (inputs, gears, allNumbers, i, j) = arg;
        
        var isDigitTop = IsDigit(inputs[i - 1][j]);
        if (i > 0 && isDigitTop && !IsChecked(gears, i - 1, j))
        {
            var gear = FindGear(allNumbers, i - 1, j);
            yield return gear;
        }
            
        var isDigitBottom = IsDigit(inputs[i + 1][j]);
        if (i < inputs.Length - 1 && isDigitBottom && !IsChecked(gears,i + 1, j))
        {
            var gear = FindGear(allNumbers,i + 1, j);
            yield return gear;
        }
    }
    
    private static IEnumerable< NumberContext> GetDiagonallyAdjacentGears(Arg arg)
    {
        var (inputs, gears, allNumbers, i, j) = arg;
        
        var isDigitTopLeft = IsDigit(inputs[i - 1][j - 1]);
        if (i > 0 && j > 0 
                  && isDigitTopLeft 
                  && !IsChecked(gears,i - 1, j - 1))
        {
            var gear = FindGear(allNumbers, i - 1, j - 1);
            yield return gear;
        }

        var isDigitTopRight = IsDigit(inputs[i - 1][j + 1]);
        if (i > 0 && j < inputs[0].Length - 1 
                  && isDigitTopRight 
                  && !IsChecked(gears,i - 1, j + 1))
        {
            var gear = FindGear(allNumbers,i - 1, j + 1);
            yield return gear;
        }

        var isDigitBottomRight = IsDigit(inputs[i + 1][j + 1]);
        if (i < inputs[0].Length - 1 && j < inputs[0].Length - 1 
                                     && isDigitBottomRight 
                                     && !IsChecked(gears, i + 1, j + 1))
        {
            var gear = FindGear(allNumbers, i + 1, j + 1);
            yield return gear;
        }
        
        var isDigitBottomLeft = IsDigit(inputs[i + 1][j - 1]);
        if (i < inputs[0].Length - 1 && j > 0 
                                     && isDigitBottomLeft 
                                     && !IsChecked(gears, i + 1, j - 1))
        {
            var gear = FindGear(allNumbers, i + 1, j - 1);
            yield return gear;
        }
    }
}