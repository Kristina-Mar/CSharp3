namespace ToDoList.Test;

public class UnitTest1
{
    [Fact]
    public void Divide_WithoutRemainder_Succeeds()
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        var result = calculator.DivideInt(6, 3);

        // Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public void DivideInt_WithoutRemainder_ReturnsDivideByZeroException()
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        //var divideAction = calculator.DivideInt(6, 0);

        // Assert
        Assert.Throws<DivideByZeroException>(() => calculator.DivideInt(6, 0));
    }

    [Fact]
    public void DivideFloat_WithoutRemainder_ReturnsInfinity()
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        var result = calculator.DivideFloat(6, 0);

        // Assert
        Assert.Equal(float.PositiveInfinity, result);
    }

    [Fact]
    public void DivideInt_WithoutRemainder_SuccessfulTrue()
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        var result = calculator.DivideInt(6, 3) == 2;

        // Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData(10, 5, 2)]
    [InlineData(30, 3, 10)]
    public void DivideInt_WithoutRemainder_Successful2(int value1, int value2, int expectedResult)
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        var result = calculator.DivideInt(value1, value2);

        // Assert
        Assert.Equal(expectedResult, result);
    }
}

public class Calculator
{
    public int DivideInt(int dividend, int divisor)
    {
        return dividend / divisor;
    }

    public float DivideFloat(float dividend, float divisor)
    {
        return dividend / divisor;
    }
}
