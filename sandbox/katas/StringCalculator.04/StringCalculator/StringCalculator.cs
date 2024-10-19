namespace StringCalculator;

public class StringCalculator
{
    private string _numbersWorkingVersion = string.Empty;
    private string _defaultDelimiter = ",";
    private string _exceptionMessage = "Negatives not allowed: ";
    private List<int> _exceptionListOfNegativeNumbers = [];

    public int Add(string numbers)
    {
        _numbersWorkingVersion = numbers;

        if (_numbersWorkingVersion == string.Empty)
        {
            return 0;
        }
        if (HasOnlyOneNumber())
        {
            return int.Parse(_numbersWorkingVersion);
        }
        if (HasMultipleDelimiters())
        {
            _numbersWorkingVersion = HandleMultipleDelimiters();
        }
        if (HasDelimiterOfDefinedLength())
        {
            _numbersWorkingVersion = HandleDelimiterOfDefinedLegth();
        }
        if (HasCustomSingleCharDelimiter())
        {
            _numbersWorkingVersion = HandleCustomSingleCharDelimiter();
        }
        if (HasLineBreaks())
        {
            _numbersWorkingVersion = HandleLineBreaks();
        }

        var arrayOfNumbers = ParseStringIntoNumberArray();

        if (HasNegativeNumbers(arrayOfNumbers))
        {
            ThrowNegativeNumbersNotAllowedException(arrayOfNumbers);
        }

        return arrayOfNumbers.Sum();
    }

    private bool HasOnlyOneNumber() => int.TryParse(_numbersWorkingVersion, out _);

    private bool HasMultipleDelimiters() => _numbersWorkingVersion.StartsWith("//[") && _numbersWorkingVersion.Count(n => n == '[') > 1;

    private bool HasDelimiterOfDefinedLength() => _numbersWorkingVersion.StartsWith("//[");

    private bool HasCustomSingleCharDelimiter() => _numbersWorkingVersion.StartsWith("//");

    private bool HasLineBreaks() => _numbersWorkingVersion.Contains('\n');

    private bool HasNegativeNumbers(int[] arrayOfNumbers) => arrayOfNumbers.Any(n => n < 0);

    private string HandleMultipleDelimiters()
    {
        int indexEndOfLine = _numbersWorkingVersion.IndexOf('\n');
        int indexEndOfFirstDelimiter = _numbersWorkingVersion.IndexOf(']');
        _defaultDelimiter = _numbersWorkingVersion.Substring(3, indexEndOfFirstDelimiter - 3);

        int secondDelimiterStartIndex = _numbersWorkingVersion.IndexOf('[', indexEndOfFirstDelimiter) + 1;
        int indexEndOfSecondDelimiter = _numbersWorkingVersion.IndexOf(']', indexEndOfFirstDelimiter + 1);
        string secondDelimiter = _numbersWorkingVersion.Substring(secondDelimiterStartIndex, indexEndOfSecondDelimiter - secondDelimiterStartIndex);

        _numbersWorkingVersion = _numbersWorkingVersion.Substring(indexEndOfLine + 1);
        _numbersWorkingVersion = _numbersWorkingVersion.Replace(secondDelimiter, _defaultDelimiter);
        return _numbersWorkingVersion;
    }

    private string HandleDelimiterOfDefinedLegth()
    {
        int indexEndOfLine = _numbersWorkingVersion.IndexOf('\n');
        int lengthOfDelimiter = _numbersWorkingVersion.IndexOf(']') - 3;
        _defaultDelimiter = _numbersWorkingVersion.Substring(3, lengthOfDelimiter);
        _numbersWorkingVersion = _numbersWorkingVersion.Substring(indexEndOfLine + 1);
        return _numbersWorkingVersion;
    }

    private string HandleCustomSingleCharDelimiter()
    {
        int indexEndOfLine = _numbersWorkingVersion.IndexOf('\n');
        _defaultDelimiter = _numbersWorkingVersion.Substring(2, 1);
        _numbersWorkingVersion = _numbersWorkingVersion.Substring(indexEndOfLine + 1);
        return _numbersWorkingVersion;
    }

    private string HandleLineBreaks()
    {
        _numbersWorkingVersion = _numbersWorkingVersion.Replace("\n", _defaultDelimiter);
        return _numbersWorkingVersion;
    }

    private int[] ParseStringIntoNumberArray()
    {
        string[] arrayOfNumbersAsStrings = _numbersWorkingVersion.Split(_defaultDelimiter);
        int[] arrayOfNumbers = new int[arrayOfNumbersAsStrings.Length];
        for (int i = 0; i < arrayOfNumbersAsStrings.Length; i++)
        {
            arrayOfNumbers[i] = int.TryParse(arrayOfNumbersAsStrings[i], out int singleNumber) ? singleNumber : 0;
            if (singleNumber > 1000)
            {
                arrayOfNumbers[i] = 0;
            }
        }

        return arrayOfNumbers;
    }

    private void ThrowNegativeNumbersNotAllowedException(int[] arrayOfNumbers)
    {
        foreach (int n in arrayOfNumbers.Where(n => n < 0))
        {
            _exceptionListOfNegativeNumbers.Add(n);
        }
        throw new ArgumentException($"{_exceptionMessage}{string.Join(", ", _exceptionListOfNegativeNumbers)}");
    }
}
