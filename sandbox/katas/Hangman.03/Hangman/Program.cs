Console.WriteLine($"Welcome to the game of hangman.");

while (true)
{
    Hangman hangman = new();
    Console.WriteLine($"Guess an animal. You have a maximum of {hangman.MaxNumberOfIncorrectGuesses} incorrect guesses.");
    Console.WriteLine($"Your word: {string.Join(" ", hangman.UncoveredWord)}");
    while (hangman.GameIsInProgress)
    {
        char guessedLetter = char.ToUpper(Console.ReadKey().KeyChar);
        Console.WriteLine();
        Console.WriteLine(hangman.Guess(guessedLetter));
        Console.WriteLine(hangman.CheckGameStatus());
    }
    Console.WriteLine("Would you like to play again? Press 'y' or 'Y' to start a new game. Press any other key to exit.");
    if (char.ToUpper(Console.ReadKey().KeyChar) != 'Y')
    {
        return;
    }
    Console.Clear();
}

