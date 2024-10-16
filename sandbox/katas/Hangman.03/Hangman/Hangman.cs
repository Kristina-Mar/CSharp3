
public class Hangman
{
    private List<string> _wordsToGuess = ["PORCUPINE", "PLATYPUS", "ANTEATER", "CROCODILE", "ARMADILLO", "TAPIR", "MAMMOTH", "PELICAN", "BABOON"];
    private string _wordToGuess = string.Empty;
    public bool GameIsInProgress { get; private set; }
    public int MaxNumberOfIncorrectGuesses { get; private set; } = 6;
    public char[] UncoveredWord { get; private set; }
    public int NumberOfIncorrectGuesses { get; private set; }
    public List<char> GuessedLetters { get; private set; } = [];
    public Hangman()
    {
        Random randomNumberGenerator = new();
        int indexOfWordToGuess = randomNumberGenerator.Next(_wordsToGuess.Count);
        _wordToGuess = _wordsToGuess[indexOfWordToGuess];
        UncoveredWord = new char[_wordToGuess.Length];
        for (int i = 0; i < UncoveredWord.Length; i++)
        {
            UncoveredWord[i] = '_';
        }
        GameIsInProgress = true;
    }

    public string Guess(char guessedLetter)
    {
        /*
        char obsahuje vela statickych metod, na zaklade ktorych je lahko overovat characters (IsNumber, IsWhiteSpace atd.)
        Pre tento pripad je lepsie pouzit IsLetter, Regex je nakladny a nie je tu nutny
        */
        if (!char.IsLetter(guessedLetter))
        {
            return $"You can only guess letters of the English alphabet!";
        }
        if (GuessedLetters.Contains(guessedLetter))
        {
            return $"You've already guessed {guessedLetter}.";
        }

        GuessedLetters.Add(guessedLetter);
        if (_wordToGuess.Contains(guessedLetter))
        {
            for (int i = 0; i < _wordToGuess.Length; i++)
            {
                if (_wordToGuess[i] == guessedLetter)
                {
                    UncoveredWord[i] = guessedLetter;
                }
            }
            return $"Correct!";
        }
        NumberOfIncorrectGuesses++;
        return $"Incorrect!";
    }

    public string CheckGameStatus()
    {
        if (!UncoveredWord.Contains('_'))
        {
            GameIsInProgress = false;
            return $"Congratulations, you win! The word was {_wordToGuess}.";
        }
        if (NumberOfIncorrectGuesses == MaxNumberOfIncorrectGuesses)
        {
            GameIsInProgress = false;
            return $"Game over. You have reached the maximum number of incorrect guesses. The word you were guessing was {_wordToGuess}.";
        }
        return $"{string.Join(" ", UncoveredWord)}, guessed letters: {string.Join(", ", GuessedLetters)}, number of incorrect guesses: {NumberOfIncorrectGuesses}/{MaxNumberOfIncorrectGuesses}. Guess again.";
    }
}
