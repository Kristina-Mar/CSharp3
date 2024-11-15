namespace Calculator.Backend;

public class Calculations
{
    public double Result { get; set; }

    public void SetFirstNumber(double number1) => Result = number1;

    public double Calculate(string symbol, double number2)
    {
        switch (symbol)
        {
            case "+":
                Result += number2;
                return Result;
            case "-":
                Result -= number2;
                return Result;
            case "*":
                Result *= number2;
                return Result;
            case "÷":
                Result /= number2;
                return Result;
            case "^":
                Result = Math.Pow(Result, number2);
                return Result;
            default: // This case won't happen.
                return 0;
        }
    }
}
