namespace StringCalculator.Test;

public class UnitTests
{
    [Fact]
    public void Add_ParameterEmptyString_ReturnsZero()
    {
        StringCalculator calculator = new();

        int result = calculator.Add(string.Empty);

        Assert.Equal(0, result);
    }

    [Fact]
    public void Add_ParameterOneNumber_ReturnsNumber()
    {
        StringCalculator calculator = new();

        int result = calculator.Add("5");

        Assert.Equal(5, result);
    }

    [Theory]
    [InlineData("5,3", 8)]
    [InlineData("5,3,4", 12)]
    [InlineData("5,3,4,1,8", 21)]
    public void Add_ParameterMultipleNumbersSeparatedByCommas_ReturnsResult(string numbers, int expectedResult)
    {
        StringCalculator calculator = new();

        int actualResult = calculator.Add(numbers);

        Assert.Equal(expectedResult, actualResult);
    }

    [Theory]
    [InlineData("1\n2,3", 6)]
    [InlineData("1\n2\n3", 6)]
    [InlineData("1,5\n2,3\n1", 12)]
    public void Add_ParameterSeparatedByNewLines_ReturnsResult(string numbers, int expectedResult)
    {
        StringCalculator calculator = new();

        int actualResult = calculator.Add(numbers);

        Assert.Equal(expectedResult, actualResult);
    }

    [Theory]
    [InlineData("//;\n1;4;5", 10)]
    [InlineData("//|\n1|4|5", 10)]
    [InlineData("//;\n1;4\n5", 10)]
    public void Add_ParameterSeparatedByDifferentDelimiter_ReturnsResult(string numbers, int expectedResult)
    {
        StringCalculator calculator = new();

        int actualResult = calculator.Add(numbers);

        Assert.Equal(expectedResult, actualResult);
    }

    [Theory]
    [InlineData("//;\n1;4;-5", "Negatives not allowed: -5")]
    [InlineData("1,-4,-5", "Negatives not allowed: -4, -5")]
    [InlineData("1,-4\n-5", "Negatives not allowed: -4, -5")]
    public void Add_ParameterIncludeNegativeNumber_ThrowsException(string numbers, string expectedMessage)
    {
        StringCalculator calculator = new();

        var ex = Assert.Throws<ArgumentException>(() => calculator.Add(numbers));
        Assert.Contains(expectedMessage, ex.Message);
    }

    [Theory]
    [InlineData("//;\n1000;4;5", 1009)]
    [InlineData("//|\n1|4000|5000", 1)]
    [InlineData("//;\n1001;4000\n5000", 0)]
    public void Add_ParameterIncludesNumberLargerThanThousand_ResultIgnoresNumbersLargerThanThousand(string numbers, int expectedResult)
    {
        StringCalculator calculator = new();

        int actualResult = calculator.Add(numbers);

        Assert.Equal(expectedResult, actualResult);
    }

    [Theory]
    [InlineData("//[|||]\n1|||2|||3", 6)]
    [InlineData("//[, ]\n1, 2, 3", 6)]
    [InlineData("//[%%]\n1%%2%%3", 6)]
    public void Add_ParameterIncludesDelimitersLongerThanOneCharacter_ReturnsResult(string numbers, int expectedResult)
    {
        StringCalculator calculator = new();

        int actualResult = calculator.Add(numbers);

        Assert.Equal(expectedResult, actualResult);
    }

    [Theory]
    [InlineData("//[|][;]\n1|2;3", 6)]
    [InlineData("//[%][,]\n1,2%3", 6)]
    [InlineData("//[|][;]\n1;2;3", 6)]
    public void Add_ParameterIncludesMultipleDelimiters_ReturnsResult(string numbers, int expectedResult)
    {
        StringCalculator calculator = new();

        int actualResult = calculator.Add(numbers);

        Assert.Equal(expectedResult, actualResult);
    }

    [Theory]
    [InlineData("//[||][;]\n1||2;3", 6)]
    [InlineData("//[%%%][,,]\n1,,2%%%3", 6)]
    [InlineData("//[|][;;]\n1;;2;;3", 6)]
    public void Add_ParameterIncludesMultipleDelimitersOfAnyLength_ReturnsResult(string numbers, int expectedResult)
    {
        StringCalculator calculator = new();

        int actualResult = calculator.Add(numbers);

        Assert.Equal(expectedResult, actualResult);
    }
}
