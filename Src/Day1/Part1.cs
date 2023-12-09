namespace AdventOfCode.Day1;

public class Part1
{
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
    
    private static int ExtractNumber(string input)
    {
        var (firstNumber, lastNumber) = GetNumbers(input);
        var firstNumberChar = (char)(firstNumber + 48);
        var lastNumberChar = (char)(lastNumber + 48);

        var resultChars = new[] { firstNumberChar, lastNumberChar };
        
        var numberString = new string(resultChars);
        
        return int.Parse(numberString);
    }

    private static (int firstNumber, int lastNumber) GetNumbers(string input)
    {
        var numbers = new List<double>();
        
        foreach (var ch in input)
        {
            if (char.IsDigit(ch))
            {
                numbers.Add(char.GetNumericValue(ch));     
            }
        }

        return ((int)numbers.First(), (int)numbers.Last());
    }
}