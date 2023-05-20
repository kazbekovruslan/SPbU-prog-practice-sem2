namespace StackCalculator;

/// <summary>
/// Realisation of stack based on linked list.
/// </summary>
public class LinkedListStack : IStack
{
    private LinkedList<double> list;

    public LinkedListStack()
    {
        list = new LinkedList<double>();
    }

    /// <inheritdoc/>
    public void Push(double value)
    {
        list.AddLast(value);
    }

    /// <inheritdoc/>
    public double Pop()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Can't pop from empty stack!");
        }
        var poppedElement = list.Last();
        list.RemoveLast();
        return poppedElement;
    }

    /// <inheritdoc/>
    public bool IsEmpty
        => list.First == null;
}