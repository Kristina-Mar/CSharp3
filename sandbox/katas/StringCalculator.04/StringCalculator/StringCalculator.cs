namespace StringCalculator;

public class StringCalculator
{
    private int[] arrayOfNumbers;
    private List<string> delimiters = [",", "\n"];
    private string exceptionMessage = "Negatives not allowed: ";
    private List<int> exceptionListOfNegativeNumbers = [];

    public int Add(string numbers)
    {
        if (numbers == string.Empty)
        {
            return 0;
        }

        if (int.TryParse(numbers, out _))
        {
            return int.Parse(numbers);
        }

        if (numbers.StartsWith("//"))
        {
            string[] headerAndNumbers = numbers.Split('\n', 2);
            string delimitersHeader = headerAndNumbers[0];
            numbers = headerAndNumbers[1];
            string[] delimitersHeaderArray = delimitersHeader.Split(['/', '[', ']'], StringSplitOptions.RemoveEmptyEntries);
            foreach (var d in delimitersHeaderArray)
            {
                delimiters.Add(d);
            }
        }

        string[] arrayOfNumbersAsStrings = numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

        arrayOfNumbers = new int[arrayOfNumbersAsStrings.Length];
        for (int i = 0; i < arrayOfNumbersAsStrings.Length; i++)
        {
            arrayOfNumbers[i] = int.TryParse(arrayOfNumbersAsStrings[i], out int singleNumber) ? singleNumber : 0;
            if (singleNumber > 1000)
            {
                arrayOfNumbers[i] = 0;
            }
        }

        if (HasNegativeNumbers(arrayOfNumbers))
        {
            ThrowNegativeNumbersNotAllowedException(arrayOfNumbers);
        }

        return arrayOfNumbers.Sum();
    }

    private bool HasNegativeNumbers(int[] arrayOfNumbers) => arrayOfNumbers.Any(n => n < 0);

    private void ThrowNegativeNumbersNotAllowedException(int[] arrayOfNumbers)
    {
        foreach (int n in arrayOfNumbers.Where(n => n < 0))
        {
            exceptionListOfNegativeNumbers.Add(n);
        }
        throw new ArgumentException($"{exceptionMessage}{string.Join(", ", exceptionListOfNegativeNumbers)}");
    }
}
