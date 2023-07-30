namespace MapFilterFold;

using System.Collections.Generic;

/// <summary>
/// Static class for static methods Map, Filter and Fold.
/// </summary>
public static class MapFilterFold
{
    /// <summary>
    /// Applies function to all elements of the list.
    /// </summary>
    /// <param name="list">Input list.</param>
    /// <param name="function">Function that will be applied to elements.</param>
    /// <typeparam name="T">Type of elements in input list.</typeparam>
    /// <typeparam name="R">Type of output value of the function.</typeparam>
    /// <returns>List of elements to which the function has been applied</returns>
    public static List<R> Map<T, R>(List<T> list, Func<T, R> function)
    {
        var result = new List<R>();

        foreach (var element in list)
        {
            result.Add(function(element));
        }

        return result;
    }

    /// <summary>
    /// Filters elements of the list by the predicate.
    /// </summary>
    /// <param name="list">Input list.</param>
    /// <param name="predicate">Predicate - function that returns bool value.</param>
    /// <typeparam name="T">Type of elements in input list.</typeparam>
    /// <returns>List of filtered elements - elements for which the predicate is true.</returns>
    public static List<T> Filter<T>(List<T> list, Predicate<T> predicate)
    {
        var result = new List<T>();

        foreach (var element in list)
        {
            if (predicate(element))
            {
                result.Add(element);
            }
        }

        return result;
    }

    /// <summary>
    /// Accumulates the value that was received from the list by the function.
    /// </summary>
    /// <param name="list">Input list.</param>
    /// <param name="result">Accumulated value.</param>
    /// <param name="function">Function that </param>
    /// <typeparam name="T">Type of elements in input list.</typeparam>
    /// <typeparam name="R">Type of accumulated value.</typeparam>
    /// <returns>Accumulated value.</returns>
    public static R Fold<T, R>(List<T> list, R result, Func<R, T, R> function)
    {
        foreach (var element in list)
        {
            result = function(result, element);
        }

        return result;
    }
}