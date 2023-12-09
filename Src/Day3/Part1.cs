namespace AdventOfCode.Day3;

public class Part1
{
    private string[] _inputs = [];
    public int Solve(string[] inputs)
    {
        _inputs = inputs;
        var sum = 0;
        var numberIndexAdjacency = new Dictionary<int, bool>();
        
        for (var i = 0; i < _inputs.Length; i++)
        {
            for (var j = 0; j < _inputs[i].Length; j++)
            { 
                var ch = _inputs[i][j];
                
                if (char.IsDigit(ch))
                {
                    numberIndexAdjacency[j] = IsAdjacentToSymbol(i, j);
                    if (j != _inputs[i].Length - 1) continue;
                }

                if (numberIndexAdjacency.Any(v => v.Value))
                {
                    var digits = numberIndexAdjacency
                        .Select(kvp => _inputs[i][kvp.Key])
                        .ToArray();
                    
                    sum += int.Parse(new string(digits));
                }
                
                numberIndexAdjacency.Clear();
            }
        }

        return sum;
    }

    private static bool IsSymbol(char ch)
    {
        return ch != '.' && !char.IsDigit(ch);
    }

    private bool IsHorizontallyAdjacent(int i, int j)
    {
        if (j > 0 && j < _inputs[0].Length - 1)
        {
            return IsSymbol(_inputs[i][j - 1]) || IsSymbol(_inputs[i][j + 1]);
        }

        return false;
    }
    
    private bool IsVerticallyAdjacent(int i, int j)
    {
        if (i > 0 && i < _inputs.Length - 1)
        {
            return IsSymbol(_inputs[i - 1][j]) || IsSymbol(_inputs[i + 1][j]);
        }

        return false;
    }
    
    private bool IsDiagonallyAdjacent(int i, int j)
    {
        var isDiagonallyAdjacent = false;
        
        if (i > 0 && j > 0)
        {
            isDiagonallyAdjacent |= IsSymbol(_inputs[i - 1][j - 1]);
        }

        if (i > 0 && j < _inputs[0].Length - 1)
        {
            isDiagonallyAdjacent |= IsSymbol(_inputs[i - 1][j + 1]);
        }

        if (i < _inputs[0].Length - 1 && j < _inputs[0].Length - 1)
        {
            isDiagonallyAdjacent |= IsSymbol(_inputs[i + 1][j + 1]);
        }
        
        if (i < _inputs[0].Length - 1 && j > 0)
        {
            isDiagonallyAdjacent |= IsSymbol(_inputs[i + 1][j - 1]);
        }

        return isDiagonallyAdjacent;
    }

    private bool IsAdjacentToSymbol(int i, int j)
    {
        return IsVerticallyAdjacent(i, j) 
               || IsHorizontallyAdjacent(i, j) 
               || IsDiagonallyAdjacent(i, j);
    }
}