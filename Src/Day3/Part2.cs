using System.Text;

namespace AdventOfCode.Day3;

public class Part2
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

    private readonly List<NumberContext> _allNumbers = [];
    private readonly List<NumberContext> _gears = [];

    private string[] _inputs = [];
    
    public int Solve(string[] inputs)
    {
        _inputs = inputs;
        var sum = 0;
        var indexes = new List<int>();
        
        for (var i = 0; i < _inputs.Length; i++)
        {
            for (var j = 0; j < _inputs[i].Length; j++)
            { 
                var ch = _inputs[i][j];
                
                if (char.IsDigit(ch))
                {
                    indexes.Add(j);
                    if (j != _inputs[i].Length - 1) continue;
                }

                if (indexes.Count > 0)
                {
                    var digits = indexes
                        .Select(index => _inputs[i][index])
                        .ToArray();
                        
                    var number = int.Parse(new string(digits));
                    _allNumbers.Add(new NumberContext(
                        i,
                        indexes.ToArray(),
                        number));
                }
                
                indexes.Clear();
            }
        }
        
        for (var i = 0; i < _inputs.Length; i++)
        {
            for (var j = 0; j < _inputs[i].Length; j++)
            {
                var ch = _inputs[i][j];

                if (ch != '*') continue;
                
                var isAdjacent = IsAdjacentToSymbol(i, j);
                
                if (!isAdjacent) continue;
                
                var gearRatio = _gears[^1].Value * _gears[^2].Value;
                sum += gearRatio;
            }
        }
        
        _gears.Clear();
        
        return sum;
    }

    private static bool IsDigit(char ch)
    {
        return char.IsDigit(ch);
    }
    
    private bool AddGear(int i, int j)
    {
        if (_gears.Any(gear => gear.Row == i && (gear.Columns.Contains(j - 1)
                              || gear.Columns.Contains(j + 1))))
        {
            return false;
        }
        
        var matchingGear = _allNumbers.First(ctx => ctx.Row == i && ctx.Columns.Contains(j));
        _gears.Add(matchingGear);
        
        return true;
    }

    private int IsHorizontallyAdjacent(int i, int j)
    {
        if (j <= 0 || j >= _inputs[0].Length - 1)
        {
            return 0;
        }

        var matches = 0;
        
        var isDigitLeft = IsDigit(_inputs[i][j - 1]);
        if (isDigitLeft)
        {
            var result = AddGear(i, j - 1);
            if (result) matches++;
        }
        
        var isDigitRight = IsDigit(_inputs[i][j + 1]);
        if (isDigitRight)
        {
            var result = AddGear(i, j + 1);
            if (result) matches++;
        }
            
        return matches;
    }
    
    private int IsVerticallyAdjacent(int i, int j)
    {
        if (i <= 0 || i >= _inputs.Length - 1)
        {
            return 0;
        }
        
        var matches = 0;
        
        var isDigitTop = IsDigit(_inputs[i - 1][j]);
        if (isDigitTop)
        {
            var result = AddGear(i - 1, j);
            if (result) matches++;
        }
            
        var isDigitBottom = IsDigit(_inputs[i + 1][j]);
        if (isDigitBottom)
        {
            var result = AddGear(i + 1, j);
            if (result) matches++;
        }
        
        return matches;
    }
    
    private int IsDiagonallyAdjacent(int i, int j)
    {
        var matches = 0;
        
        if (i > 0 && j > 0)
        {
            var isDigitTopLeft = IsDigit(_inputs[i - 1][j - 1]);
            if (isDigitTopLeft)
            {
                var result = AddGear(i - 1, j - 1);
                if (result) matches++;
            }
        }

        if (i > 0 && j < _inputs[0].Length - 1)
        {
            var isDigitTopRight = IsDigit(_inputs[i - 1][j + 1]);
            if (isDigitTopRight)
            {
                var result = AddGear(i - 1, j + 1);
                if (result) matches++;
            }
        }

        if (i < _inputs[0].Length - 1 && j < _inputs[0].Length - 1)
        {
            var isDigitBottomRight = IsDigit(_inputs[i + 1][j + 1]);
            if (isDigitBottomRight)
            {
                var result = AddGear(i + 1, j + 1);
                if (result) matches++;
            }
        }
        
        if (i < _inputs[0].Length - 1 && j > 0)
        {
            var isDigitBottomLeft = IsDigit(_inputs[i + 1][j - 1]);
            if (isDigitBottomLeft)
            {
                var result = AddGear(i + 1, j - 1);
                if (result) matches++;
            }
        }

        return matches;
    }

    private bool IsAdjacentToSymbol(int i, int j)
    {
        var verticalMatches = IsVerticallyAdjacent(i, j);
        var horizontalMatches = IsHorizontallyAdjacent(i, j);
        var diagonalMatches = IsDiagonallyAdjacent(i, j);

        return verticalMatches + horizontalMatches + diagonalMatches == MaxNumberOfAdjacentNumbers;
    }
}