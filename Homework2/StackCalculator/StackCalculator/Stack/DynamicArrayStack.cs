namespace StackCalculator;

using System;

/// <summary>
/// Realisation of stack based on dynamic array.
/// </summary>
public class DynamicArrayStack : IStack
{
    private List<double> array;

    public DynamicArrayStack()
    {
        array = new List<double>();
    }

    /// <inheritdoc/>
    public void Push(double value)
    {
        array.Add(value);
    }

    /// <inheritdoc/>
    public double Pop()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Can't pop from empty stack!");
        }
        var poppedElement = array[array.Count - 1];
        array.RemoveAt(array.Count - 1);
        return poppedElement;
    }

    /// <inheritdoc/>
    public bool IsEmpty
        => array.Count == 0;
}