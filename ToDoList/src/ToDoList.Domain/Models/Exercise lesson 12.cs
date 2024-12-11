using System;

namespace ToDoList.Domain.Models;

public class Exercise_lesson_12
{
    private int field;
    public Exercise_lesson_12(int field) => Vlastnost = field;

    public int Vlastnost
    {
        get => field;
        set => field = value;
    }

    /*private IEnumerable<V> Distinct<T, V>(this IEnumerable<T> source, Func<T, V> selector)
    {
        HashSet<V> seenValues = new HashSet<V>();
        foreach (var item in source)
        {
            var value = selector(item);
            if (seenValues.Add(value))
            {
                yield return value;
            }
        }
    }*/
}
