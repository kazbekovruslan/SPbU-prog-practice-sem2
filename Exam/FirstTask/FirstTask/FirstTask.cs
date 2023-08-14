namespace firsttask;

using System;

public static class MostFrequent
{
    static int FindMostFrequentElementInArray(int[] array)
    {
        if (array == null)
        {
            throw new ArgumentNullException("Array can't be null!");
        }

        if (array.Length == 0)
        {
            throw new ArgumentException("Array can't be empty!");
        }

        var dictionary = new Dictionary<int, int>();

        foreach (var element in array)
        {
            if (dictionary.ContainsKey(element))
            {
                ++dictionary[element];
            }
            else
            {
                dictionary.Add(element, 1);
            }
        }

        var maxFrequency = 0;
        int mostFrequentElement = array[0];
        foreach (var pair in dictionary)
        {
            if (pair.Value >= maxFrequency)
            {
                maxFrequency = pair.Value;
                mostFrequentElement = pair.Key;
            }
        }

        return mostFrequentElement;
    }
}
