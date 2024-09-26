// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;

Console.WriteLine("Welcome to Greed - a press-your-luck dice rolling game.");
Console.WriteLine("How many dice would you like to roll? Select a number from 1 to 6.");
Console.WriteLine("Press Enter to exit.");
int numberOfDice;
while (true)
{
    string playerInput = Console.ReadLine();
    if (playerInput == string.Empty)
    {
        return;
    }
    bool numberOfDiceIsCorrect = int.TryParse(playerInput, out numberOfDice);
    while (!numberOfDiceIsCorrect || !(numberOfDice > 0 && numberOfDice < 7))
    {
        Console.WriteLine("Select a number from 1 to 6.");
        numberOfDiceIsCorrect = int.TryParse(Console.ReadLine(), out numberOfDice);
    }
    Console.Clear();
    GreedGame game = new GreedGame();
    game.RollDice(numberOfDice);
    game.CheckScore();
    Console.WriteLine();
    Console.WriteLine("Would you like to roll again? Select a number from 1 to 6.");
    Console.WriteLine("Press Enter to exit.");
}
