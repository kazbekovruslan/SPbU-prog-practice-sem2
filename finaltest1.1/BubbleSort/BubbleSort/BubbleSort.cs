namespace BubbleSort;

using System.Collections.Generic;

/// <summary>
/// Class that realize bubble sort method. 
/// </summary>
/// <typeparam name="T">Input type for bubble sort method.</typeparam>
public static class BubbleSorter<T>
{
    static void Swap(List<T> list, int index1, int index2)
    {
        T temporaryElement = list[index1];
        list[index1] = list[index2];
        list[index2] = temporaryElement;
    }

    public static void Sort(List<T> list, IComparer<T> comparer)
    {
        for (int i = 0; i < list.Count; ++i)
        {
            for (int j = 0; j < list.Count - i - 1; ++j)
            {
                if (comparer.Compare(list[j], list[j + 1]) > 0)
                {
                    Swap(list, j, j + 1);
                }
            }
        }
    }
}