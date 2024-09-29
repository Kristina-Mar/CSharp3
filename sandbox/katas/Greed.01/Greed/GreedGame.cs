using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

public class GreedGame
{
    /*
    Riesenie sa mi paci a nema ziadne velke chyby, parkrat som si hru pustila a preklikala a funguje spravne :)
    Nasledujuce komentare a zmeny odo mna su skor len nejake best practices co sa pisania kodu tyka.
    */

    // Pri type int je defaultna hodnota uz 0, preto ju netreba nastavovat
    private int _score;

    // V .NET 8 je skvela novinka inicializovania Listu skrz [], mne osobne sa to viac paci ako stary sposob.
    // Pouzivam to aj v praci, vsade kde sa da (nedavno sme presli na .NET 8 a snazim sa novy kod pisat co najnovsim sposobom)
    private List<int> _roll = [];

    public void RollDice(int numberOfDice)
    {
        // Neviem, ci ste uz mali na hodinach "var", ale je to zauzity sposob, ako deklarovat lokalne premenne
        // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/declarations#implicitly-typed-local-variables
        // Ak nie je jasne pouzitie, daj vediet a vysvetlim blizsie :)
        // Opravila som to len v tejto metode ako priklad, zvysok zostal povodne
        var randomNumberGenerator = new Random();
        for (var i = 0; i < numberOfDice; i++)
        {
            _roll.Add(randomNumberGenerator.Next(1, 7));
        }

        DisplayRolledDice();
    }

    // Ak ma metoda len jeden riadok, zvykne sa pouzivat expression body pre lepsiu citatelnost
    // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members
    // Podobne aj pri metode ShowScore()
    private void DisplayRolledDice() => Console.WriteLine($"You've rolled: {string.Join(", ", _roll)}");

    public void CheckScore()
    {
        // Namiesto metody Enumerable.Count() je lepsie pouzit v tomto pripade property Count
        // Vyberam z odpovede od ChatGPT:
        // In summary, use Count() for LINQ operations and conditions, and use Count when you simply want the total number of elements in a collection.
        if (_roll.Count == 6)
        {
            CheckSixOfAKind();
            CheckStraightSix();
            CheckThreePairs();
        }
        if (_roll.Count() >= 5)
        {
            CheckFiveOfAKind();
        }
        if (_roll.Count() >= 4)
        {
            CheckFourOfAKind();
        }
        if (_roll.Count() >= 3)
        {
            CheckThreeOfAKind();
        }
        if (_roll.Count() > 0)
        {
            CheckOnes();
            CheckFives();
        }
        ShowScore();
    }

    private void CheckSixOfAKind()
    {
        if (_roll.Distinct().Count() == 1)
        {
            int scoringNumber = _roll[0];
            if (scoringNumber == 1)
            {
                _score += 8000;
            }
            else
            {
                _score += scoringNumber * 100 * 8;
            }
            _roll.Clear();
        }
    }
    private void CheckStraightSix()
    {
        // Tu by som napisala tu podmienku jednoduchsie:
        // if (_roll.Distinct() == 6)
        // Vieme, ze elementov je 6 a kazdy musi byt iny a to staci, aby to bolo straight six
        List<int> straightSix = new List<int>() { 1, 2, 3, 4, 5, 6 };
        if (_roll.Order().ToList().SequenceEqual(straightSix))
        {
            _score += 1200;
            _roll.Clear();
        }
    }
    private void CheckThreePairs()
    {
        if (_roll.Distinct().Count() == 3)
        {
            bool thereAreThreePairs = true;
            foreach (int i in _roll.Distinct())
            {
                if (_roll.Count(n => n == i) != 2)
                {
                    thereAreThreePairs = false;
                    return;
                }
            }
            if (thereAreThreePairs)
            {
                _score += 800;
                _roll.Clear();
            }
        }
    }
    private void CheckFiveOfAKind()
    {
        foreach (int i in _roll.Distinct())
        {
            if (_roll.Count(n => n == i) == 5)
            {
                // Nie je nutne vytvarat novu premennu scoringNumber, staci rovno pouzit i
                // Malo by to zmysel, iba ak by sme scoringNumber potrebovali pouzit mimo iteraciu cyklu.
                // Rovnako pri CheckFourOfAKind()
                int scoringNumber = i;
                if (scoringNumber == 1)
                {
                    _score += 4000;
                }
                else
                {
                    _score += scoringNumber * 100 * 4;
                }
                _roll.RemoveAll(n => n == scoringNumber);
                return;
            }
        }
    }
    private void CheckFourOfAKind()
    {
        foreach (int i in _roll.Distinct())
        {
            if (_roll.Count(n => n == i) == 4)
            {
                int scoringNumber = i;
                if (scoringNumber == 1)
                {
                    _score += 2000;
                }
                else
                {
                    _score += scoringNumber * 100 * 2;
                }
                _roll.RemoveAll(n => n == scoringNumber);
                return;
            }
        }
    }
    private void CheckThreeOfAKind()
    {
        List<int> scoringNumbers = new List<int>();
        foreach (int i in _roll.Distinct())
        {
            if (_roll.Count(n => n == i) == 3)
            {
                scoringNumbers.Add(i);
                if (i == 1)
                {
                    _score += 1000;
                }
                else
                {
                    _score += i * 100;
                }
            }
        }
        if (scoringNumbers.Count() > 0)
        {
            foreach (int i in scoringNumbers)
            {
                _roll.RemoveAll(n => n == i);
            }
        }
    }
    private void CheckOnes()
    {
        foreach (int n in _roll)
        {
            if (n == 1)
            {
                _score += 100;
            }
        }
    }
    private void CheckFives()
    {
        foreach (int n in _roll)
        {
            if (n == 5)
            {
                _score += 50;
            }
        }
    }

    private void ShowScore()
    {
        Console.WriteLine($"You scored {_score}.");
    }
}
