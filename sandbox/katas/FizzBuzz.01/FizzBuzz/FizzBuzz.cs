using System;

public class FizzBuzz
{
    public void CountTo(int lastNumber)
    {
        for (int i = 1; i <= lastNumber; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine("Fizz");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine("Buzz");
            }
            else
            {
                Console.WriteLine(i);
            }
        }
    }

    public void CountToExtra(int lastNumber)
    {
        for (int i = 1; i <= lastNumber; i++)
        {
            string currentNumberAsString = i.ToString();
            if (currentNumberAsString.Contains('3') && currentNumberAsString.Contains('5'))
            {
                Console.WriteLine("FizzBuzz");
            }
            else if (currentNumberAsString.Contains('3'))
            {
                Console.WriteLine("Fizz");
            }
            else if (currentNumberAsString.Contains('5'))
            {
                Console.WriteLine("Buzz");
            }
            else
            {
                Console.WriteLine(currentNumberAsString);
            }
        }
    }
}
