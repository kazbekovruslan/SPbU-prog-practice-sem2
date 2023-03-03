namespace InsertionSort;

using System;

class Program
{
    static void Swap(ref int firstElement, ref int secondElement)
    {
        int temporaryElement = firstElement;
        firstElement = secondElement;
        secondElement = temporaryElement;
    }

    static void InsertionSort(int[] array)
    {
        for (int i = 1; i < array.Length; ++i)
        {
            int swapIndex = i;
            while (swapIndex > 0 && array[swapIndex - 1] > array[swapIndex])
            {
                Swap(ref array[swapIndex - 1], ref array[swapIndex]);
                --swapIndex;
            }
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("This program can sort your array by insertion sort.");
        Console.Write("Enter the amount of elements in the array (must be positive and integer): ");
        int arraySize = -1;

        while (!int.TryParse(Console.ReadLine(), out arraySize) || arraySize <= 0)
        {
            Console.WriteLine("Incorrect input! Size of the array must be positive integer number. Try again!");
            Console.Write("Enter the amount of elements in the array (must be positive): ");
        }

        var array = new int[arraySize];

        Console.Write("Enter elements of the array: ");
        for (int i = 0; i < arraySize; ++i)
        {
            while (!int.TryParse(Console.ReadLine(), out array[i]))
            {
                Console.WriteLine("Incorrect input! Element of array is integer number. Try again!");
                Console.Write("Enter the remaining elements: ");
            }
        }

        InsertionSort(array);

        Console.WriteLine("Your sorted array: ");
        for (int i = 0; i < arraySize; ++i)
        {
            Console.Write($"{array[i]} ");
        }
    }
}


