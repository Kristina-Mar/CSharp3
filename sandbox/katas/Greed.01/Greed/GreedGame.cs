using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

public class GreedGame
{
    private int _score = 0;
    private List<int> _roll = new List<int>();

    public void RollDice(int numberOfDice)
    {
        Random randomNumberGenerator = new Random();
        for (int i = 0; i < numberOfDice; i++)
        {
            _roll.Add(randomNumberGenerator.Next(1, 7));
        }

        DisplayRolledDice();
    }

    private void DisplayRolledDice()
    {
        Console.WriteLine($"You've rolled: {String.Join(", ", _roll)}");
    }

    public void CheckScore()
    {
        if (_roll.Count() == 6)
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
