using System.Runtime.InteropServices;

Hangman hangman = new();
Console.WriteLine($"Welcome to the game of hangman. Guess an animal. You have a maximum of {hangman.MaxNumberOfIncorrectGuesses} incorrect guesses.");
while (hangman.GameIsInProgress)
{
    char guessedLetter = char.ToUpper(Console.ReadKey().KeyChar);
    Console.WriteLine();
    Console.WriteLine(hangman.Guess(guessedLetter));
    Console.WriteLine(hangman.CheckGameStatus());
}
