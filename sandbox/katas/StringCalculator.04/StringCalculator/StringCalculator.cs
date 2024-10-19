namespace StringCalculator;

public class StringCalculator
{
    private string _delimiter = ",";
    private string _exceptionMessage = "Negatives not allowed: ";
    List<int> _exceptionListOfNegativeNumbers = [];
    public int Add(string numbers)
    {
        if (numbers == string.Empty)
        {
            return 0;
        }
        if (int.TryParse(numbers, out int oneNumber))
        {
            return oneNumber;
        }
        if (numbers.StartsWith("//[") && numbers.Count(n => n == '[') > 1)
        {
            int indexEndOfLine = numbers.IndexOf('\n');
            int indexEndOfFirstDelimiter = numbers.IndexOf(']');
            _delimiter = numbers.Substring(3, indexEndOfFirstDelimiter - 3);

            int secondDelimiterStartIndex = numbers.IndexOf('[', indexEndOfFirstDelimiter) + 1;
            int indexEndOfSecondDelimiter = numbers.IndexOf(']', indexEndOfFirstDelimiter + 1);
            string secondDelimiter = numbers.Substring(secondDelimiterStartIndex, indexEndOfSecondDelimiter - secondDelimiterStartIndex);
            numbers = numbers.Substring(indexEndOfLine + 1);
            numbers = numbers.Replace(secondDelimiter, _delimiter);
        }
        if (numbers.StartsWith("//["))
        {
            int indexEndOfLine = numbers.IndexOf('\n');
            int lengthOfDelimiter = numbers.IndexOf(']') - 3;
            _delimiter = numbers.Substring(3, lengthOfDelimiter);
            numbers = numbers.Substring(indexEndOfLine + 1);
        }
        if (numbers.StartsWith("//"))
        {
            int indexEndOfLine = numbers.IndexOf('\n');
            _delimiter = numbers.Substring(2, 1);
            numbers = numbers.Substring(indexEndOfLine + 1);
        }
        if (numbers.Contains('\n'))
        {
            numbers = numbers.Replace("\n", _delimiter);
        }
        string[] arrayOfNumbersAsStrings = numbers.Split(_delimiter);
        int[] arrayOfNumbers = new int[arrayOfNumbersAsStrings.Length];
        for (int i = 0; i < arrayOfNumbersAsStrings.Length; i++)
        {
            arrayOfNumbers[i] = int.TryParse(arrayOfNumbersAsStrings[i], out int singleNumber) ? singleNumber : 0;
            if (singleNumber > 1000)
            {
                arrayOfNumbers[i] = 0;
            }
        }

        if (arrayOfNumbers.Any(n => n < 0))
        {
            foreach (int n in arrayOfNumbers.Where(n => n < 0))
            {
                _exceptionListOfNegativeNumbers.Add(n);
            }
            throw new ArgumentException($"{_exceptionMessage}{string.Join(", ", _exceptionListOfNegativeNumbers)}");
        }

        return arrayOfNumbers.Sum();
    }
}
